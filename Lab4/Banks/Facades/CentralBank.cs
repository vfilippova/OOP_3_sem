using System;
using System.Collections.Generic;
using System.Linq;
using Banks.Entities;
using Banks.Interfaces;
using Banks.Models;

namespace Banks.Facades;

public class CentralBank
{
    private readonly List<Bank> _banks = new ();
    private readonly List<Client> _clients = new ();
    public IEnumerable<Bank> Banks => _banks;
    public IEnumerable<Client> Clients => _clients;
    public IEnumerable<BankClientAccount> Accounts => _banks.SelectMany(x => x.Accounts).ToList();
    public Transaction Transfer(BankClientAccount fromAccount, BankClientAccount toAccount, decimal cash)
    {
        fromAccount.Withdraw(GetBank(fromAccount).Config ?? throw new InvalidOperationException(), cash);
        toAccount.Add(cash);
        var transaction = new Transaction(cash, GetBank(fromAccount).Config);
        transaction.AddSender(fromAccount);
        transaction.AddReceiver(toAccount);
        return transaction;
    }

    public void AddClient(Client client)
    {
        _clients.Add(client);
    }

    public Bank AddBank(string name)
    {
        var bank = new Bank(name, Guid.NewGuid());
        _banks.Add(bank);
        return bank;
    }

    public Bank GetBank(Guid id)
    {
        if (_banks.FirstOrDefault(x => x.Id == id) is null)
        {
            throw new InvalidOperationException();
        }

        return _banks.FirstOrDefault(x => x.Id == id);
    }

    public Bank GetBank(BankClientAccount bankClientAccount)
    {
        if (_banks.FirstOrDefault(x => x.Accounts.Contains(bankClientAccount)) is null)
        {
            throw new InvalidOperationException();
        }

        return _banks.FirstOrDefault(x => x.Accounts.Contains(bankClientAccount));
    }

    public Client GetClient(Guid id)
    {
        if (_clients.FirstOrDefault(x => x.Id == id) is null)
        {
            throw new InvalidOperationException();
        }

        return _clients.FirstOrDefault(x => x.Id == id);
    }

    public BankClientAccount GetAccount(Guid id)
    {
        if (_banks.SelectMany(x => x.Accounts).FirstOrDefault(x => x.Id == id) is null)
        {
            throw new InvalidOperationException();
        }

        return _banks.SelectMany(x => x.Accounts).FirstOrDefault(x => x.Id == id);
    }

    internal void Notify()
    {
        foreach (Bank bank in _banks)
        {
            bank.Notify();
        }
    }
}