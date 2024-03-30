using Backend.Interfaces;
using SmartTrade.Models;

namespace Backend.Services
{
    public class TechnoProductService : ProductService<TechnoProduct>
    {
        public TechnoProductService(ITechnoProductRepository repository) : base(repository)
        {
        }
    }
}