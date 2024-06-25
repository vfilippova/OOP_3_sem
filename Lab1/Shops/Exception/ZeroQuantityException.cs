namespace Shops.Exception;

public class ZeroQuantityException : SystemException
{
    public ZeroQuantityException(int quantity)
        : base($"It's not possible to buy {quantity} items")
    {
    }
}