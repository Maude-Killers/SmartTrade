using Backend.Domain.DesignPattern;
using Backend.Domain.DesignPattern.FactoryMethod;
using Backend.Interfaces;
using Backend.Services;
using Backend.Utils;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SmartTrade.Models;

namespace Backend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ListController : ControllerBase
    {
        private ListFactory? _factory;
        private List? _domain;
        private readonly ILogger<ListController> _logger;

        public ListController(ILogger<ListController> logger)
        {
            _logger = logger;
        }

        [Authorize(Roles = "client")]
        [HttpGet("/list", Name = "GetList")]

        //Id de persona desde jwt, recuperar wishlist de persona
        public ActionResult<List> Get()
        {
            var token = HttpContext.Request.Cookies["JWTToken"];
            var email = AuthHelpers.GetEmail(token);

            var item = _domain.GetByEmail(email);

            if (item == null)
            {
                return NotFound();
            }

            return item;
        }


        //Recuperar correo de persona desde jwt y modificar addproduct
        [Authorize(Roles = "client")]
        [HttpPost("/wishlist")]
        public IActionResult AddProductWishlist(Product product)
        {
            var token = HttpContext.Request.Cookies["JWTToken"];
            var email = AuthHelpers.GetEmail(token);
            _factory = new WishListFactory();
            _domain = _factory.CreateList();

            if (!string.IsNullOrEmpty(email))
            {
                _domain.AddProduct(product, email);
                return Ok();
            }
            return BadRequest("No contiene un Email válido");
        }

        [Authorize(Roles = "client")]
        [HttpPost("/laterlist")]
        public IActionResult AddProductLaterlist(Product product)
        {
            var token = HttpContext.Request.Cookies["JWTToken"];
            var email = AuthHelpers.GetEmail(token);
            _factory = new LaterListFactory();
            _domain = _factory.CreateList();

            if (!string.IsNullOrEmpty(email))
            {
                _domain.AddProduct(product, email);
                return Ok();
            }
            return BadRequest("No contiene un Email válido");
        }



        [HttpDelete("/lists/{List_code}", Name = "DeleteList")]
        public IActionResult DeleteProduct(Product product)
        {
            var token = HttpContext.Request.Cookies["JWTToken"];
            var email = AuthHelpers.GetEmail(token);
            _factory = new WishListFactory();
            _domain = _factory.CreateList();

            if (!string.IsNullOrEmpty(email))
            {
                _domain.DeleteProduct(product, email);
                return Ok();
            }
            return BadRequest("No contiene un Email válido");
        }

        [HttpGet("/wishlist")]
        public ActionResult<List<ListProduct>> GetWishListProducts()
        {
            var token = HttpContext.Request.Cookies["JWTToken"];
            var email = AuthHelpers.GetEmail(token);
            _factory = new WishListFactory();
            _domain = _factory.CreateList();
            var products = _domain.GetAll(email);
            if (products == null)
            {
                return NotFound();
            }

            return Ok(products);
        }

        [HttpGet("/laterlist")]
        public ActionResult<List<ListProduct>> GetLaterListProducts()
        {
            var token = HttpContext.Request.Cookies["JWTToken"];
            var email = AuthHelpers.GetEmail(token);
            var products = _domain.GetAll(email);
            if (products == null)
            {
                return NotFound();
            }

            return Ok(products);
        }
    }
}