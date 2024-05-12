using Backend.Repositories;

namespace Backend.Models;
public partial class Client
{
    public void AddProductToWishList(int productCode)
    {
        var productRepository = new ProductRepository(AppServices.GetDbContext());
        var product = productRepository.Get(productCode);
        this.WishList.Add(product);
    }

    public void AddProductToLaterList(int productCode)
    {
        var productRepository = new ProductRepository(AppServices.GetDbContext());
        var product = productRepository.Get(productCode);
        this.LaterList.Add(product);
    }

    public void AddProductToGiftList(int productCode)
    {
        var productRepository = new ProductRepository(AppServices.GetDbContext());
        var product = productRepository.Get(productCode);
        this.GiftList.Add(product);
    }

    public void AddProductToShoppingCart(int productCode)
    {
        var productRepository = new ProductRepository(AppServices.GetDbContext());
        var product = productRepository.Get(productCode);
        this.ShoppingCart.Add(product);
    }

    public void RemoveProductToWishList(int productCode)
    {
        this.WishList.RemoveAll(x => x.Product_code == productCode);
        var listRepository = new WishListRepository(AppServices.GetDbContext());
        var productRepository = new ProductRepository(AppServices.GetDbContext());
        listRepository.DeleteProduct(productRepository.Get(productCode), this);
    }

    public void RemoveProductToLaterList(int productCode)
    {
        this.LaterList.RemoveAll(x => x.Product_code == productCode);
        var listRepository = new LaterListRepository(AppServices.GetDbContext());
        var productRepository = new ProductRepository(AppServices.GetDbContext());
        listRepository.DeleteProduct(productRepository.Get(productCode), this);
    }

    public void RemoveProductToGiftList(int productCode)
    {
        this.GiftList.RemoveAll(x => x.Product_code == productCode);
        var listRepository = new GiftListRepository(AppServices.GetDbContext());
        var productRepository = new ProductRepository(AppServices.GetDbContext());
        listRepository.DeleteProduct(productRepository.Get(productCode), this);
    }

    public void RemoveProductToShoppingCart(int productCode)
    {
        this.ShoppingCart.RemoveAll(x => x.Product_code == productCode);
        var listRepository = new ShoppingCartRepository(AppServices.GetDbContext());
        var productRepository = new ProductRepository(AppServices.GetDbContext());
        listRepository.DeleteProduct(productRepository.Get(productCode), this);
    }

    public List<Product> GetWishListProducts()
    {
        return this.WishList;
    }

    public List<Product> GetLaterListProducts()
    {
        return this.LaterList;
    }

    public List<Product> GetGiftListProducts()
    {
        return this.GiftList;
    }

    public List<Product> GetShoppingCartProducts()
    {
        return this.ShoppingCart;
    }
}