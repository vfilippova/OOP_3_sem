using Shops.Exception;
using Shops.Models;
namespace Shops.Entities;

public class Shop
{
    private Dictionary<Product, decimal> _products = new Dictionary<Product, decimal>();
    public Shop(int id, ShopName shopName, string address)
    {
        Id = id;
        ShopName = shopName;
        Address = address;
    }

    public ShopName ShopName { get; set; }
    public int Id { get; }
    public string Address { get; set; }

    public void SetProductPrice(Product product, decimal price)
    {
        if (!_products.ContainsKey(product))
        {
            _products[product] = 0;
        }

        _products[product] = price;
    }

    public decimal GetProductPrice(Product product)
    {
        return _products[product];
    }

    public bool IsProductInShop(Product product)
    {
        return _products.ContainsKey(product);
    }
}
