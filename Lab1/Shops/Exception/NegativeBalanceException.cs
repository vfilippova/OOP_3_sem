namespace Shops.Exception;

public class NegativeBalanceException : SystemException
{
    public NegativeBalanceException(decimal balance)
        : base($"Negative balance {balance}")
    {
    }
}