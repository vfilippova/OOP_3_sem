namespace Shops.Exception;

public class NonPositiveQuantityException : SystemException
{
    public NonPositiveQuantityException(decimal balance)
        : base($"Negative balance {balance}")
    {
    }
}