using Backend.Interfaces;
using Backend.Domain.DesignPattern;
using Backend.Repositories;

namespace Backend.Models;
public partial class Client : Observer
{
    private readonly IProductRepository _productRepository;
    private readonly IListRepository _listRepository;
    public Client(IProductRepository productRepository, IListRepository listRepository) { 
        
        _productRepository = productRepository;
        _listRepository = listRepository;
    
    }
    public void AddProductToWishList(int productCode)
    {
        var product = SmartTrade.Singleton.GetProduct(productCode);
        this.WishList.Add(product);
    }

    public void AddProductToLaterList(int productCode)
    {
        var product = SmartTrade.Singleton.GetProduct(productCode);
        this.LaterList.Add(product);
    }

    public void AddProductToGiftList(int productCode)
    {
        var product = SmartTrade.Singleton.GetProduct(productCode);
        this.GiftList.Add(product);
    }

    public void AddProductToShoppingCart(int productCode)
    {
        var product = SmartTrade.Singleton.GetProduct(productCode);
        this.ShoppingCart.Add(product);
        product.AddObserver(this);
    }

    public void RemoveProductToWishList(int productCode)
    {
        this.WishList.RemoveAll(x => x.Product_code == productCode);
        _listRepository.DeleteProduct(_productRepository.Get(productCode), this);
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
        _listRepository.DeleteProduct(_productRepository.Get(productCode), this);
        var product = _productRepository.Get(productCode);
        _listRepository.DeleteProduct(product, this);
        product.RemoveObserver(this);
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

    public void Update()
    {
        Console.WriteLine("Disculpe profe no lo actualizamos la logica todavia " + this.Email);
    }

    public Order ConfirmOrder()
    {
        Order order = BuyProducts();
        this.Orders.Add(order);
        order.RemovePurchasedStock();
        return order;
    }

    // No me culpes a mi culpa al sistema

    public List<Order> Orders { get; set; }

    private Order BuyProducts()
    {
        throw new NotImplementedException();
    }

    public class Order
    {
        internal void RemovePurchasedStock()
        {
            throw new NotImplementedException();
        }
    }
}