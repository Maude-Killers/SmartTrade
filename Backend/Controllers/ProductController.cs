using Backend.Interfaces;
using Microsoft.AspNetCore.Mvc;
using SmartTrade.Models;

namespace Backend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly ILogger<ProductController> _logger;
        private readonly ProductEntity _domain;

        public ProductController(ProductEntity domain, ILogger<ProductController> logger)
        {
            _logger = logger;
            _domain = domain;
        }

        [HttpGet(Name = "GetProduct")]
        public IEnumerable<Product> Get()
        {
            return _domain.GetAll();
        }

        [HttpGet("/product/{Product_code}", Name = "GetProductByProduct_code")]
        public ActionResult<Product> Get(int Product_code)
        {
            var product = _domain.GetById(Product_code);

            if (product == null)
            {
                return NotFound();
            }

            return product;
        }

        [HttpPost(Name = "CreateProduct")]
        public void Post(Product product)
        {
            _domain.CreateProduct(product);
        }

        [HttpPut("/product/{Product_code}", Name = "EditProduct")]
        public void Put(int Product_code, Product product)
        {
            _domain.EditProduct(Product_code, product);
        }

        [HttpDelete("/Product/{Product_code}", Name = "DeleteProduct")]
        public void Delete(int product_code)
        {
            _domain.DeleteProduct(product_code);
        }
    }
}