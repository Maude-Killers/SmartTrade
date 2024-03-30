using Backend.Interfaces;
using SmartTrade.Models;

namespace Backend.Services
{
    public class GroceryProductService : ProductService<GroceryProduct>
    {
        public GroceryProductService(IGroceryProductRepository repository) : base(repository)
        {
        }
    }
}