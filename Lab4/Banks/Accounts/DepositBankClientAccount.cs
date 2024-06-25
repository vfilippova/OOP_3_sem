using Banks.Builders;
using Banks.Entities;
using Banks.Interfaces;
using Banks.Models;

namespace Banks.Accounts;

public class DepositBankClientAccount : BankClientAccount
{
    public DepositBankClientAccount(Client client, DateTime creationDate)
        : base(client, creationDate)
    {
    }

    internal override void Withdraw(BankConfig config, decimal cash)
    {
        DateTime time = CreationDate + new TimeSpan(DaysCounter, 0, 0, 0);
        if (DaysCounter % DateTime.DaysInMonth(time.Year, time.Month) != 0)
        {
            throw new Exception("Нельзя снять сумму с депазитного счета");
        }
    }

    internal override void Notify(BankConfig config)
    {
        decimal percent = config.GetBySum(Cash);
        AdditionalCash += Cash * percent / 100;
        DateTime time = CreationDate + new TimeSpan(DaysCounter, 0, 0, 0);
        if (DaysCounter % DateTime.DaysInMonth(time.Year, time.Month) != 0) return;
        Cash += AdditionalCash;
        AdditionalCash = 0;
    }
}