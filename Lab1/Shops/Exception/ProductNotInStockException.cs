namespace Shops.Exception;

public class ProductNotInStockException : SystemException
{
    public ProductNotInStockException(string productName)
        : base($"The product {productName} is not in stock")
    {
    }
}