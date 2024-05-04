using Backend.Interfaces;
using Backend.Repositories;
using Backend.Services;
using DataTransferObject;
using Microsoft.AspNetCore.Mvc;
using SmartTrade.Models;

namespace Backend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly ILogger<ProductController> _logger;
        private readonly IProductRepository _productRepository;
        private readonly ProductService _productService;

        public ProductController(
            ILogger<ProductController> logger,
            IProductRepository productRepository,
            ProductService productService
        ) {
            _logger = logger;
            _productRepository = productRepository;
            _productService = productService;
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
            return _productRepository.GetAllSportProducts();
        }

        [HttpGet("/products/Grocery")]
        public IEnumerable<Product> GetGroceryProducts()
        {
            return _productRepository.GetAllGroceryProducts();
        }

        [HttpGet("/products/Technology")]
        public IEnumerable<Product> GetTechnoProducts()
        {
            return _productRepository.GetAllTechnoProducts();
        }

        [HttpGet("/search")]
        public IEnumerable<Product> SearchProducts([FromQuery] string? value)
        {
            if (string.IsNullOrEmpty(value)) return Enumerable.Empty<Product>();
            return ((ProductRepository)_productRepository).Search(value);
        }

        [HttpPost("/products")]
        public void CreateProduct(ProductDTO product)
        {
            _productService.CreateProduct(product);
        }
    }
}