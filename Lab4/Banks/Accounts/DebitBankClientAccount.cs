using Banks.Entities;
using Banks.Interfaces;
using Banks.Models;

namespace Banks.Accounts;

public class DebitBankClientAccount : BankClientAccount
{
    public DebitBankClientAccount(Client client, DateTime creationDate)
        : base(client, creationDate)
    {
    }

    internal override void Withdraw(BankConfig config, decimal cash)
    {
        if (Cash - cash < 0)
        {
            throw new Exception("Сумма должна остается выше нуля");
        }

        Cash -= cash;
    }

    internal override void Notify(BankConfig config)
    {
        DaysCounter++;
        DateTime time = CreationDate + new TimeSpan(DaysCounter, 0, 0, 0);
        AdditionalCash += Cash * config.DebitPercent / 100;
        if (DaysCounter % DateTime.DaysInMonth(time.Year, time.Month) != 0) return;
        Cash += AdditionalCash;
        AdditionalCash = 0;
    }
}