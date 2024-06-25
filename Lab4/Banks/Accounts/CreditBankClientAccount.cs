using Banks.Entities;
using Banks.Interfaces;
using Banks.Models;

namespace Banks.Accounts;

public class CreditBankClientAccount : BankClientAccount
{
    public CreditBankClientAccount(Client client, DateTime creationDate)
        : base(client, creationDate)
    {
    }

    internal override void Withdraw(BankConfig config, decimal cash)
    {
        if (Cash < 0)
        {
            AdditionalCash += cash * config.CreditPercent / 100;
        }

        Cash -= cash;
    }

    internal override void Notify(BankConfig config)
    {
        return;
    }
}