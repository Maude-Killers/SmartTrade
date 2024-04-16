using Backend.Interfaces;
using SmartTrade.Models;

namespace Backend.Services
{
    public class SportProductService : ProductService<SportProduct>, ISportProductService
    {
        public SportProductService(ISportProductRepository repository) : base(repository)
        {
        }
    }
}