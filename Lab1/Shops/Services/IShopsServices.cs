using System.Text.RegularExpressions;
using Shops.Entities;
using Shops.Models;

namespace Shops.Services;

public interface IShopsServices
{
     Shop AddShop(ShopName name, string address);
     Customer AddCustomer(string name, int balance);
     Product AddProduct(ProductName name);
     void AddProductToShop(Shop shop, Product product, decimal price, int quantity);
     Product? FindProduct(int id);
     Product GetProduct(int id);
     IReadOnlyList<Product> FindProducts(Shop shop);
     IReadOnlyList<Shop> FindShopsWithCheapestProduct(Product product);
     void BuyProduct(Customer customer, Product product, Shop shop, int quantity);

     void ChangeQuantityProduct(int quantity, Product product, Shop shop);
     void ChangeProductPrice(decimal price, Product product, Shop shop);
}