using Backend.Database;
using Backend.Models;

namespace Backend.Interfaces;

public interface IProductRepository : EntityRepository<Product, int>
{
    IEnumerable<SportProduct> GetAllSportProducts();
    IEnumerable<TechnoProduct> GetAllTechnoProducts();
    IEnumerable<GroceryProduct> GetAllGroceryProducts();
}