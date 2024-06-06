using Backend.Database;
using Backend.Models;

namespace Backend.Interfaces;
public interface IShoppingCartRepository : IListRepository
{
    void DeleteItem(Product product, Client client);
}