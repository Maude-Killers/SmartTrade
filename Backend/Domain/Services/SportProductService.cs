using Backend.Interfaces;
using SmartTrade.Models;

namespace Backend.Services
{
    public class SportProductService : ProductService<SportProduct>
    {
        public SportProductService(ISportProductRepository repository) : base(repository)
        {
        }
    }
}