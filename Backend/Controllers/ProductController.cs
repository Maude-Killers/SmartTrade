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
        private readonly Backend.Models.SmartTrade _smartTrade;
        private readonly ILogger<ProductController> _logger;

        public ProductController(Backend.Models.SmartTrade smartTrade, ILogger<ProductController> logger)
        {
            _logger = logger;
            _smartTrade = smartTrade;
        }

        [HttpGet("/products", Name = "GetProduct")]
        public IEnumerable<Product> Get()
        {
            return _smartTrade.GetAllProducts();
        }

        [HttpGet("/products/{Product_code}", Name = "GetProductByProduct_code")]
        public Product Get(int Product_code)
        {
            return _smartTrade.GetProduct(Product_code);
        }

        [HttpGet("/products/Sport")]
        public IEnumerable<Product> GetSportProducts()
        {
            return _smartTrade.GetAllSportProducts();
        }

        [HttpGet("/products/Grocery")]
        public IEnumerable<Product> GetGroceryProducts()
        {
            return _smartTrade.GetAllGroceryProducts();
        }

        [HttpGet("/products/Technology")]
        public IEnumerable<Product> GetTechnoProducts()
        {
            return _smartTrade.GetAllTechnoProducts();
        }

        [HttpGet("/search")]
        public List<Product> SearchProducts([FromQuery] string? value)
        {
            if (string.IsNullOrEmpty(value)) return new List<Product>();
            return _smartTrade.SearchProduct(value);
        }

        [HttpPost("/products")]
        public void CreateProduct(Product product)
        {
            _smartTrade.CreateProduct(product);
        }
    }
}