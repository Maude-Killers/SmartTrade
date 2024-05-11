using Backend.Database;
using SmartTrade.Models;

namespace Backend.Interfaces;

public interface IListRepository
{
    List<Product> GetProducts(Client client);
    void AddProduct(Product product, Client client);
    void DeleteProduct(Product product, Client client);
}