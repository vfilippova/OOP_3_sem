/*using Banks.Exceptions;
namespace Banks.Builders;

public class BankConfigB
{
    private SortedDictionary<decimal, decimal> _percentBySum;

    public BankConfigB(decimal creditPercent, decimal debitPercent, decimal highestDepositPercent, decimal limitForInvalidClients)
    {
        CreditPercent = creditPercent;
        DebitPercent = debitPercent;

        HighestDepositPercent = highestDepositPercent;
        LimitForInvalidClients = limitForInvalidClients;
        _percentBySum = new SortedDictionary<decimal, decimal>();
    }

    public decimal CreditPercent { get; private set; }
    public decimal DebitPercent { get; private set; }
    public decimal HighestDepositPercent => _percentBySum.Values.LastOrDefault();
    public decimal LimitForInvalidClients { get; private set; }

    public BankConfigB AddSumAndPercent(decimal sum, decimal percent)
    {
        if (_percentBySum.ContainsKey(sum))
        {
            throw new ConfigException();
        }

        _percentBySum.Add(sum, percent);
        return this;
    }

    public decimal GetBySum(decimal sum)
    {
        foreach (decimal kSum in _percentBySum.Keys)
        {
            if (sum < kSum)
            {
                return _percentBySum[kSum];
            }
        }

        return HighestDepositPercent;
    }
}*/
