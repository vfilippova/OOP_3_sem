using Shops.Models;

namespace Shops.Entities;

public class Product
{
    private Dictionary<Shop, int> _shops = new Dictionary<Shop, int>();
    public Product(ProductName productName, int id)
    {
        Id = id;
        ProductName = productName ?? throw new ArgumentNullException();
    }

    public ProductName ProductName { get; set;  }
    public int Id { get; set; }

    public void SetProductQuantity(Shop shop, int quantity)
    {
        if (quantity == 0)
        {
            throw new ArgumentNullException();
        }

        _shops[shop] = quantity;
    }

    public int GetProductQuantity(Shop shop)
    {
        return _shops[shop];
    }

    public bool IsProductInStock(Shop shop)
    {
        if (!IsProductInShop(shop))
        {
            return false;
        }

        return _shops[shop] > 0;
    }

    public List<Shop> GetShops()
    {
        return _shops.Keys.ToList();
    }

    public bool IsProductInShop(Shop shop)
    {
        return _shops.ContainsKey(shop);
    }
}
