using Shops.Services;
namespace Shops.Exception;

public class ErrorProductPriceException : System.Exception
{
    public ErrorProductPriceException(decimal price)
        : base($"Error product price {price}")
    {
    }
}