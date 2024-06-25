using Shops.Models;
namespace Shops.Exception;

public class InvalidShopException : System.Exception
{
    public InvalidShopException(string shopName)
        : base($"Shop {shopName} does not exist")
        {
        }
}