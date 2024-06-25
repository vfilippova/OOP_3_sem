namespace Banks.Models;

public class DepositPercentModel
{
    private SortedDictionary<decimal, decimal> _dictionary;

    public DepositPercentModel()
    {
        _dictionary = new SortedDictionary<decimal, decimal>();
    }

    public SortedDictionary<decimal, decimal> Dictionary => _dictionary;

    public void Add(decimal sum, decimal percent)
    {
        _dictionary.Add(sum, percent);
    }
}