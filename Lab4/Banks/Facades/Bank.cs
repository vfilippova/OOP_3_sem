using System;
using System.Collections.Generic;
using System.Linq;
using Banks.Accounts;
using Banks.Entities;
using Banks.Exceptions;
using Banks.Interfaces;
using Banks.Models;

namespace Banks.Facades;

public class Bank : InfoSender
{
    private Dictionary<Client, List<BankClientAccount>> _accounts = new Dictionary<Client, List<BankClientAccount>>();

    public Bank(string name, Guid id)
    {
        Id = id;
        Name = name;
    }

    public string Name { get; }
    public List<BankClientAccount> Accounts => _accounts.Values.SelectMany(x => x).ToList();
    public List<Client> Clients => _accounts.Keys.ToList();

    public Guid Id { get; }

    public BankConfig Config { get; private set; }

    public void SetConfig(BankConfig bankConfig)
    {
        Config = bankConfig;
        Notify("Конфиг банка обновлен");
    }

    public void AddClient(Client client)
    {
        if (_accounts.ContainsKey(client))
        {
            throw new Exception($"{client} клиент уже зарегистрирован в банке");
        }

        _accounts.Add(client, new List<BankClientAccount>());
    }

    public BankClientAccount CreateAccount(Client client, AccountType accountType, DateTime addDateTime)
    {
        if (!_accounts.ContainsKey(client))
        {
            throw new Exception($"{client} не зарегистрирован в банке");
        }

        BankClientAccount bankClientAccount;
        if (accountType == AccountType.Credit)
        {
            bankClientAccount = new CreditBankClientAccount(client, addDateTime);
        }
        else if (accountType == AccountType.Debit)
        {
            bankClientAccount = new DebitBankClientAccount(client, addDateTime);
        }
        else if (accountType == AccountType.Deposit)
        {
            bankClientAccount = new DepositBankClientAccount(client, addDateTime);
        }
        else
        {
            throw new ArgumentOutOfRangeException(nameof(accountType), accountType, null);
        }

        _accounts[client].Add(bankClientAccount);
        return bankClientAccount;
    }

    public Transaction PutMoney(BankClientAccount bankClientAccount, decimal cash)
    {
        bankClientAccount.Add(cash);
        var transaction = new Transaction(cash, Config);
        transaction.AddReceiver(bankClientAccount);
        return transaction;
    }

    public Transaction WithdrawMoney(BankClientAccount bankClientAccount, decimal cash)
    {
        if (Config is null)
        {
            throw new ConfigException();
        }

        bankClientAccount.Withdraw(Config, cash);
        var transaction = new Transaction(cash, Config);
        transaction.AddSender(bankClientAccount);
        return transaction;
    }

    internal void Notify()
    {
        Dictionary<Client, List<BankClientAccount>>.ValueCollection values = _accounts.Values;
        foreach (BankClientAccount account in values.SelectMany(accountList => accountList))
        {
            account.Notify(Config);
            if (Config is null)
            {
                throw new ConfigException();
            }
        }
    }
}