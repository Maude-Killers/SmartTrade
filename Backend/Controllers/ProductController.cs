using Backend.Domain.DesignPattern;
using Backend.Domain.DesignPattern.FactoryMethod;
using Backend.Interfaces;
using Backend.Repositories;
using Microsoft.AspNetCore.Mvc;
using SmartTrade.Models;

namespace Backend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly ILogger<ProductController> _logger;
        private readonly ISportProductRepository _sportProductRepository;
        private readonly ITechnoProductRepository _technoProductRepository;
        private readonly IGroceryProductRepository _groceryProductRepository;
        private readonly IProductRepository<Product> _productRepository;

        public ProductController(
            ILogger<ProductController> logger,
            ISportProductRepository sportProductRepository,
            ITechnoProductRepository technoProductRepository,
            IGroceryProductRepository groceryProductRepository,
            IProductRepository<Product> productRepository
        ) {
            _logger = logger;
            _sportProductRepository = sportProductRepository;
            _technoProductRepository = technoProductRepository;
            _groceryProductRepository = groceryProductRepository;
            _productRepository = productRepository;
        }

        [HttpGet("/products", Name = "GetProduct")]
        public IEnumerable<Product> Get()
        {
            return _productRepository.GetAll();
        }

        [HttpGet("/products/{Product_code}", Name = "GetProductByProduct_code")]
        public Product Get(int Product_code)
        {
            return _productRepository.Get(Product_code);
        }

        [HttpGet("/products/Sport")]
        public IEnumerable<Product> GetSportProducts()
        {
            return _sportProductRepository.GetAll();
        }

        [HttpGet("/products/Grocery")]
        public IEnumerable<Product> GetGroceryProducts()
        {
            return _groceryProductRepository.GetAll();
        }

        [HttpGet("/products/Technology")]
        public IEnumerable<Product> GetTechnoProducts()
        {
            return _technoProductRepository.GetAll();
        }

        [HttpGet("/search")]
        public IEnumerable<Product> SearchProducts([FromQuery] string? value)
        {
            if (string.IsNullOrEmpty(value)) return Enumerable.Empty<Product>();
            return ((ProductRepository)_productRepository).Search(value);
        }
    }
}