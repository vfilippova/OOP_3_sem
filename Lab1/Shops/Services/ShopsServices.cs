using System.IO.Enumeration;
using System.Xml.Serialization;
using Shops.Entities;
using Shops.Exception;
using Shops.Models;
namespace Shops.Services;

public class ShopsServices : IShopsServices
{
    private List<Customer> _customers = new List<Customer>();
    private List<Product> _products = new List<Product>();
    private List<Shop> _shops = new List<Shop>();
    private int _shopId;
    private int _customerId;
    private int _productId;

    public ShopsServices()
    {
        _shopId = 1;
        _customerId = 1;
        _productId = 1;
    }

    public Shop AddShop(ShopName name, string address)
    {
        if (name == null)
        {
            throw new ("Parameter must not be null");
        }

        var newShop = new Shop(_shopId++, name, address);
        _shops?.Add(newShop);
        return newShop;
    }

    public Customer AddCustomer(string name, int balance)
    {
        if (name == null)
        {
            throw new ("Parameter must not be null");
        }

        if (balance < 0)
        {
            throw new NegativeBalanceException(balance);
        }

        var newCustomer = new Customer(name, _customerId++, balance);
        _customers?.Add(newCustomer);
        return newCustomer;
    }

    public Product AddProduct(ProductName name)
    {
        if (name is null)
        {
            throw new ("Parameter must not be null");
        }

        var newProduct = new Product(name, _productId++);
        _products?.Add(newProduct);
        return newProduct;
    }

    public void AddProductToShop(Shop shop, Product product, decimal price, int quantity)
    {
        if (shop is null)
        {
            throw new ("Shop name does not exist");
        }

        if (product is null)
        {
            throw new ("Product name does not exist");
        }

        if (price <= 0)
        {
            throw new ErrorProductPriceException(price);
        }

        if (quantity < 1)
        {
            throw new NonPositiveQuantityException(quantity);
        }

        shop.SetProductPrice(product, price);
        product.SetProductQuantity(shop, quantity);
    }

    public Product? FindProduct(int id)
    {
        return _products.FirstOrDefault(product => product.Id == id);
    }

    public Product GetProduct(int id)
    {
        return FindProduct(id) ?? throw new ("Parameter does not exist");
    }

    public IReadOnlyList<Product> FindProducts(Shop shop)
    {
        return _products!.Where(product => product.IsProductInShop(shop)).ToList();
    }

    public IReadOnlyList<Shop> FindShopsWithCheapestProduct(Product product)
    {
        decimal minPrice = _shops.Min(shop => shop.GetProductPrice(product));
        return _shops.FindAll(
            shop => shop.GetProductPrice(product) == minPrice);
    }

    public void BuyProduct(Customer customer, Product product, Shop shop, int quantity)
    {
        if (!shop.IsProductInShop(product))
        {
            throw new InvalidProductException(product.ProductName.Name, shop.ShopName.Name);
        }

        if (quantity < 1)
        {
            throw new NonPositiveQuantityException(quantity);
        }

        if (!product.IsProductInStock(shop))
        {
            throw new ProductNotInStockException(product.ProductName.Name);
        }

        if (product.GetProductQuantity(shop) - quantity < 0)
        {
            throw new NonPositiveQuantityException(product.GetProductQuantity(shop) - quantity);
        }

        if (customer.Balance - shop.GetProductPrice(product) < 0)
        {
            throw new NegativeBalanceException(customer.Balance - shop.GetProductPrice(product));
        }

        customer.Balance -= shop.GetProductPrice(product) * quantity;
        ChangeQuantityProduct(product.GetProductQuantity(shop) - quantity, product, shop);
        customer.SetProductQuantity(product, quantity);
    }

    public void ChangeQuantityProduct(int quantity, Product product, Shop shop)
    {
        product.SetProductQuantity(shop, quantity);
    }

    public void ChangeProductPrice(decimal price, Product product, Shop shop)
    {
        shop.SetProductPrice(product, price);
    }
}
