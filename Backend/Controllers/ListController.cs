using Backend.Domain.DesignPattern;
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
        [HttpGet("/List", Name = "GetList")]

        //Id de persona desde jwt, recuperar wishlist de persona
        public ActionResult<List> Get()
        {
            var token = HttpContext.Request.Cookies["JWTToken"];
            var Email = AuthHelpers.GetEmail(token);

            var item = _domain.GetByEmail(Email);
            
            if (item == null)
            {
                return NotFound();
            }

            return item;
        }

        
        //Recuperar correo de persona desde jwt y modificar addproduct
        [HttpPost("/productsList", Name = "addProduct")]
        public IActionResult AddProduct(Product product, string Email)
        {
            var token = HttpContext.Request.Cookies["JWTToken"];
            Email = AuthHelpers.GetEmail(token);
            if (!string.IsNullOrEmpty(Email))
            {
                _domain.AddProduct(product);
                return Ok();
            }
            return BadRequest("No contiene un Email válido");
        }

        
        //Recuperar correo de persona desde jwt y modificar createwishlist/ Validar si hay una lista ligada al usuario
        [HttpPost(Name = "CreateList")]
        public IActionResult CreateList()
        {
            var token = HttpContext.Request.Cookies["JWTToken"];
            var Email = AuthHelpers.GetEmail(token);
            if (string.IsNullOrEmpty(Email))
            {
                return BadRequest("El token JWT no contiene un correo electrónico válido.");
            }

            _domain.CreateList(Email);
            return Ok();
        }


        [HttpDelete("/lists/{List_code}", Name = "DeleteList")]
        public IActionResult DeleteProduct(Product product, string Email)
        {
            var token = HttpContext.Request.Cookies["JWTToken"];
            Email = AuthHelpers.GetEmail(token);
            if (!string.IsNullOrEmpty(Email))
            {
                _domain.DeleteProduct(product);
                return Ok();
            }
            return BadRequest("No contiene un Email válido");
        }
        
        }
    }