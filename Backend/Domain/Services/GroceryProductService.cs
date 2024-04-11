using Backend.Interfaces;
using SmartTrade.Models;

namespace Backend.Services
{
    public class GroceryProductService : ProductService<GroceryProduct>, IGroceryProductService
    {
        public GroceryProductService(IGroceryProductRepository repository) : base(repository)
        {
        }
    }
}