using Backend.Interfaces;
using Backend.Repositories;
using SmartTrade.Models;

public class MoveProduct
{
    private readonly IProductRepository _productRepository;
    private readonly IClientRepository _clientRepository;
    private readonly IListRepository _from;
    private readonly IListRepository _to;
    public MoveProduct(
        IProductRepository productRepository,
        IClientRepository clientRepository,
        IListRepository from,
        IListRepository to
    )
    {
        _productRepository = productRepository;
        _clientRepository = clientRepository;
        _from = from;
        _to = to;
    }

    public void Execute(string email, int product_code)
    {
        var product = _productRepository.Get(product_code);
        var client = _clientRepository.Get(email);
        _from.DeleteProduct(product, client);
        _to.AddProduct(product, client);
    }
}