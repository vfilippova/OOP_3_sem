using Shops.Exception;
namespace Shops.Models;

public class ProductName
{
    public ProductName(string productName)
    {
        Name = productName;
    }

    public string Name { get; set; }
}
