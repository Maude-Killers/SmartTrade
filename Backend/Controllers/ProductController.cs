using Backend.Domain.DesignPattern;
using Backend.Domain.DesignPattern.FactoryMethod;
using Microsoft.AspNetCore.Mvc;
using SmartTrade.Models;

namespace Backend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController : ControllerBase
    {
        private ProductFactory? _factory;
        private Product? _domain;
        private readonly ILogger<ProductController> _logger;

        public ProductController(ILogger<ProductController> logger)
        {
            _logger = logger;
        }

        [HttpGet("/products", Name = "GetProduct")]
        public IEnumerable<Product> Get()
        {
            _factory = new GenericProductFactory();
            _domain = _factory.CreateProduct();
            return _domain.GetAll();
        }

        [HttpGet("/products/{Product_code}", Name = "GetProductByProduct_code")]
        public ActionResult<Product> Get(int Product_code)
        {
            _factory = new GenericProductFactory();
            _domain = _factory.CreateProduct();
            return _domain.GetById(Product_code);
        }

        [HttpGet("/products/Sport")]
        public IEnumerable<Product> GetSportProducts()
        {
            _factory = new SportProductFactory();
            _domain = _factory.CreateProduct();
            return _domain.GetAll();
        }

        [HttpGet("/products/Grocery")]
        public IEnumerable<Product> GetGroceryProducts()
        {
            _factory = new GroceryProductFactory();
            _domain = _factory.CreateProduct();
            return _domain.GetAll();
        }

        [HttpGet("/products/Technology")]
        public IEnumerable<Product> GetTechnoProducts()
        {
            _factory = new TechnoProductFactory();
            _domain = _factory.CreateProduct();
            return _domain.GetAll();
        }

        [HttpGet("/search")]
        public IEnumerable<Product> SearchProducts([FromQuery] string? value)
        {
            if(string.IsNullOrEmpty(value)) return Enumerable.Empty<Product>();
            _factory = new GenericProductFactory();
            _domain = _factory.CreateProduct();
            return _domain.Search(value);
        }

        [HttpPost("/products", Name = "CreateProduct")]
        public void Post(Product product)
        {
            _domain.CreateProduct(product);
        }

        [HttpPut("/product/{Product_code}", Name = "EditProduct")]
        public void Put(int Product_code, Product product)
        {
            _domain.EditProduct(Product_code, product);
        }

        [HttpDelete("/products/{Product_code}", Name = "DeleteProduct")]
        public void Delete(int product_code)
        {
            _domain.DeleteProduct(product_code);
        }
    }
}