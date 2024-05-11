using Backend.Database;
using SmartTrade.Models;

namespace Backend.Interfaces;

public interface IProductRepository : EntityRepository<Product, int>
{
    IEnumerable<SportProduct> GetAllSportProducts();
    IEnumerable<TechnoProduct> GetAllTechnoProducts();
    IEnumerable<GroceryProduct> GetAllGroceryProducts();
}