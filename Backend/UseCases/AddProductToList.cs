using Backend.Interfaces;

public class AddProductToList
{
    private readonly IProductRepository _productRepository;
    private readonly IClientRepository _clientRepository;
    private readonly IListRepository _listRepository;
    public AddProductToList(IProductRepository productRepository, IClientRepository clientRepository, IListRepository listRepository)
    {
        _productRepository = productRepository;
        _clientRepository = clientRepository;
        _listRepository = listRepository;
    }

    public void AddProduct(string email, int product_code)
    {
        var product = _productRepository.Get(product_code);
        var client = _clientRepository.Get(email);
        if (product != null)
        {
            _listRepository.AddProduct(product, client);
        }
    }
}