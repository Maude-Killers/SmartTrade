using SmartTrade.Models;

namespace Backend.Interfaces
{
    public interface IListRepository
    {
        List<Product> GetProducts(Client client);
        void AddProduct(int Product_code, Client client);
        void DeleteProduct(int Product_code, Client client);
    }
}