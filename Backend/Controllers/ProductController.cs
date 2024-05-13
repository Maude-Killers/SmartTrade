using Backend.Interfaces;
using Backend.Repositories;
using Backend.Services;
using Microsoft.AspNetCore.Mvc;
using Backend.Models;

namespace Backend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly ILogger<ProductController> _logger;

        public ProductController(ILogger<ProductController> logger)
        {
            _logger = logger;
        }

        [HttpGet("/products", Name = "GetProduct")]
        public IEnumerable<Product> Get()
        {
            return SmartTrade.Singleton.GetAllProducts();
        }

        [HttpGet("/products/{Product_code}", Name = "GetProductByProduct_code")]
        public Product Get(int Product_code)
        {
            return SmartTrade.Singleton.GetProduct(Product_code);
        }

        [HttpGet("/products/Sport")]
        public IEnumerable<Product> GetSportProducts()
        {
            return SmartTrade.Singleton.GetAllSportProducts();
        }

        [HttpGet("/products/Grocery")]
        public IEnumerable<Product> GetGroceryProducts()
        {
            return SmartTrade.Singleton.GetAllGroceryProducts();
        }

        [HttpGet("/products/Technology")]
        public IEnumerable<Product> GetTechnoProducts()
        {
            return SmartTrade.Singleton.GetAllTechnoProducts();
        }

        [HttpGet("/search")]
        public List<Product> SearchProducts([FromQuery] string? value)
        {
            if (string.IsNullOrEmpty(value)) return new List<Product>();
            return SmartTrade.Singleton.SearchProduct(value);
        }

        [HttpPost("/products")]
        public void CreateProduct(Product product)
        {
            SmartTrade.Singleton.CreateProduct(product);
        }
    }
}