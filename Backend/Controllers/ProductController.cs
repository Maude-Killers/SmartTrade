using Backend.Domain.DesignPattern;
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

        [HttpGet(Name = "GetProduct")]
        public IEnumerable<Product> Get()
        {
            _factory = new SportProductFactory();
            _domain = _factory.CreateProduct();
            return _domain.GetAll();
        }

        [HttpGet("/products/{Product_code}", Name = "GetProductByProduct_code")]
        public ActionResult<Product> Get(int Product_code)
        {
            _factory = new SportProductFactory();
            _domain = _factory.CreateProduct();
            return _domain.GetById(Product_code);
        }

        [HttpPost(Name = "CreateProduct")]
        public void Post(Product product)
        {
            return;
        }

        [HttpPut("/products/{Product_code}", Name = "EditProduct")]
        public void Put(int Product_code, Product product)
        {
            return;
        }

        [HttpDelete("/Products/{Product_code}", Name = "DeleteProduct")]
        public void Delete(int product_code)
        {
            return;
        }
    }
}