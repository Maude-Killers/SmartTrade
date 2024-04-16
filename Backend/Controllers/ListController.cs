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
        private readonly IWishListService _wishListService;
        private readonly WishListService _laterListService;

        public ListController(IWishListService wishList, ILogger<ListController> logger)
        {
            _logger = logger;
            _wishListService = wishList;
        }

        [Authorize(Roles = "client")]
        [HttpGet("/List", Name = "GetList")]

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
        [HttpPost("/productsList", Name = "addProduct")]
        public IActionResult AddProduct(Product product)
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


        //Recuperar correo de persona desde jwt y modificar createwishlist/ Validar si hay una lista ligada al usuario
        [HttpPost(Name = "CreateList")]
        public IActionResult CreateList()
        {
            var token = HttpContext.Request.Cookies["JWTToken"];
            var email = AuthHelpers.GetEmail(token);
            if (string.IsNullOrEmpty(email))
            {
                return BadRequest("El token JWT no contiene un correo electrónico válido.");
            }

            _domain.CreateList(email);
            return Ok();
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
            var products = _wishListService.GetProducts(email);
            if (products == null)
            {
                return NotFound();
            }

            return Ok(products);
        }

        [HttpGet("{list_code}/Lproducts")]
        public async Task<ActionResult<List<ListProduct>>> GetLaterListProductsAsync(int list_code)
        {
            var token = HttpContext.Request.Cookies["JWTToken"];
            var email = AuthHelpers.GetEmail(token);
            var products = _wishListService.GetProducts(email);
            if (products == null)
            {
                return NotFound();
            }

            return Ok(products);
        }
    }
}