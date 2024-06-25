using Shops.Services;
namespace Shops.Exception;

public class InvalidProductException : System.Exception
{
    public InvalidProductException(string productName, string shopName)
        : base($"Product {productName} is not on sale in shop {shopName}")
        {
        }
}