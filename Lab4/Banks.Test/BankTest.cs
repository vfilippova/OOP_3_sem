using Banks.Builders;
using Banks.Entities;
using Banks.Facades;
using Banks.Interfaces;
using Banks.Models;
using Banks.TimeTool;
using Xunit;

namespace Banks.Test;

public class BankTest
{
    private readonly CentralBank _centralBank;
    private readonly TimeProvider _timeProvider;

    public BankTest()
    {
        _centralBank = new CentralBank();
        _timeProvider = new TimeProvider(_centralBank);
    }

    [Fact]
    public void AddBank()
    {
        Bank sber = _centralBank.AddBank("Sberbank");
        Assert.Contains(sber, _centralBank.Banks);
    }

    [Fact]
    public void AddClient()
    {
        Bank bank = _centralBank.AddBank("Raiffeisenbank");
        Client client = new Client("Victoria", "Filippova").AddAddress("st.Korotkay").AddPassport(111).AddInn(111);
        bank.AddClient(client);
        bank.CreateAccount(client, AccountType.Debit, _timeProvider.DateTime);
        Assert.Contains(client, bank.Clients);
    }

    [Fact]
    public void PuttMany()
    {
        Bank bank = _centralBank.AddBank("Sberbank");
        var model = new DepositPercentModel();
        model.Add(10, 2);
        model.Add(decimal.MaxValue, 3);
        BankConfig bankConfig = new BankConfig(2m, 2m, model, 10m);
        bank.SetConfig(bankConfig);
        Client client = new Client("Victoria", "Filippova").AddAddress("st.Korotkay").AddPassport(111);
        bank.AddClient(client);
        BankClientAccount bankClientAccount = bank.CreateAccount(client, AccountType.Debit, _timeProvider.DateTime);
        bank.PutMoney(bankClientAccount, 100);
        Assert.Equal(100, bankClientAccount.Cash);
    }
}