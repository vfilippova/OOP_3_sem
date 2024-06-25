using Shops.Exception;
using Shops.Models;

namespace Shops.Entities;

public class Customer
{
    private Dictionary<Product, int> _products = new Dictionary<Product, int>();
    public Customer(string name, int id, decimal balance)
    {
        if (balance < 0)
        {
            throw new NegativeBalanceException(balance);
        }

        Id = id;
        Balance = balance;
        Name = name ?? throw new ArgumentNullException();
    }

    public string Name { get; set; }
    public int Id { get; set; }
    public decimal Balance { get; set; }

    public void SetProductQuantity(Product product, int quantity)
    {
        if (!_products.ContainsKey(product))
        {
            _products[product] = 0;
        }

        _products[product] += quantity;
    }
}