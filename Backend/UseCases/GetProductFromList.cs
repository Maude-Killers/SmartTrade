using Backend.Interfaces;
using SmartTrade.Models;

public class GetProductFromList
{
    private readonly IClientRepository _clientRepository;
    private readonly IListRepository _listRepository;
    public GetProductFromList(IClientRepository clientRepository, IListRepository listRepository)
    {
        _clientRepository = clientRepository;
        _listRepository = listRepository;
    }

    public List<Product> GetProduct(string email)
    {
        var client = _clientRepository.Get(email);
        return _listRepository.GetProducts(client);
    }
}