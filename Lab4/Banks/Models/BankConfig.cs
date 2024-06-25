using Banks.Builders;
using Banks.Exceptions;

namespace Banks.Models;

public class BankConfig
{
    public BankConfig(
        decimal creditPercent,
        decimal debitPercent,
        DepositPercentModel depositPercentModel,
        decimal limitForInvalidClients)
    {
        CreditPercent = creditPercent;
        DebitPercent = debitPercent;
        if (depositPercentModel.Dictionary.Count == 0)
        {
            throw new ConfigException();
        }

        if (!depositPercentModel.Dictionary.ContainsKey(decimal.MaxValue))
        {
            throw new ConfigException();
        }

        DepositPercentModel = depositPercentModel;
        LimitForInvalidClients = limitForInvalidClients;
    }

    public decimal CreditPercent { get; private set; }
    public decimal DebitPercent { get; private set; }
    public DepositPercentModel DepositPercentModel { get; }
    public decimal LimitForInvalidClients { get; private set; }

    public decimal GetBySum(decimal sum)
    {
        foreach (decimal kSum in DepositPercentModel.Dictionary.Keys)
        {
            if (sum < kSum)
            {
                return DepositPercentModel.Dictionary[kSum];
            }
        }

        return DepositPercentModel.Dictionary.Last().Value;
    }
}