using Shops.Entities;
using Shops.Exception;
using Shops.Models;
using Shops.Services;
using Xunit;
namespace Shops.Test;

public class ShopsServicesTest
{
    [Fact]
    public void AddOfProductsToTheShop()
    {
        // arrange
        var shopService = new ShopsServices();
        Shop shop1 = shopService.AddShop(new ShopName("EUROSPAR"), "st.Chkalovskaya");
        Product product1 = shopService.AddProduct(new ProductName("milk"));

        // act
        shopService.AddProductToShop(shop1, product1, 132, 1342);

        // assert
        Assert.True(shop1.IsProductInShop(product1));
    }

    [Fact]
    public void SettingAndChangingPricesForProductsInTheShop()
    {
        // arrange
        var shopService = new ShopsServices();
        decimal expectedPrice = 100;
        Shop shop = shopService.AddShop(new ShopName("EUROSPAR"), "st.Chkalovskaya");
        Product product = shopService.AddProduct(new ProductName("butter"));

        // act
        shopService.AddProductToShop(shop, product, 100, 1312);
        shopService.ChangeProductPrice(50, product, shop);

        // assert
        Assert.NotEqual(expectedPrice, shop.GetProductPrice(product));
    }

    [Fact]
    public void SearchForAShopWithTheCheapestBatchOfProduct()
    {
        // arrange
        var shopService = new ShopsServices();
        Shop shop1 = shopService.AddShop(new ShopName("EUROSPAR"), "st.Chkalovskaya");
        Shop shop2 = shopService.AddShop(new ShopName("VkusVille"), "st.Chkalovskaya");
        Product product1 = shopService.AddProduct(new ProductName("butter"));

        // act
        shopService.AddProductToShop(shop1, product1, 25, 23);
        shopService.AddProductToShop(shop2, product1, 14, 34);

        // assert
        Assert.Contains(shop2, shopService.FindShopsWithCheapestProduct(product1));
    }

    [Fact]
    public void BuyingABatchOfProductInAShop()
    {
        // arrange
        var shopService = new ShopsServices();
        Shop shop = shopService.AddShop(new ShopName("EUROSPAR"), "st.Chkalovskaya");
        Product product = shopService.AddProduct(new ProductName("butter"));
        Customer customer = shopService.AddCustomer("Anny", 1000);
        decimal expectedBalance = 920;
        int expectedQuantity = 1;

        // act
        shopService.AddProductToShop(shop, product, 20, 5);
        shopService.BuyProduct(customer, product, shop, 4);

        // assert
        Assert.Equal(expectedBalance, customer.Balance);
        Assert.Equal(expectedQuantity, product.GetProductQuantity(shop));
    }
}