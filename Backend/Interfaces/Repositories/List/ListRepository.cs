using SmartTrade.Models;

namespace Backend.Interfaces
{
    public interface IListRepository
    {
        List<Product> GetProducts(Client client);
        void AddProduct(Product product, string Email);
        void DeleteProduct(Product product, Client client);
    }
}