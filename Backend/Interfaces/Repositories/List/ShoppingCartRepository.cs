using Backend.Database;
using SmartTrade.Models;

namespace Backend.Interfaces;
public interface IShoppingCartRepository : IListRepository
{
    void DeleteItem(Product product, Client client);
}