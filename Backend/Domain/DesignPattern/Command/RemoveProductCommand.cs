using Backend.Models;

namespace Backend.Domain.DesignPattern;

public class RemoveProductCommand : Command
{
    private readonly List<Product> _products;
    private readonly int _productId;

    public RemoveProductCommand(List<Product> products, int productId)
    {
        _products = products;
        _productId = productId;
    }

    public void Execute()
    {
        _products.Remove(SmartTrade.Singleton.GetProduct(_productId));
    }
}