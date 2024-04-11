using Backend.Interfaces;
using Backend.Services;
using Microsoft.AspNetCore.Mvc;
using SmartTrade.Models;

namespace Backend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WishListController : ControllerBase
    {
        private readonly ILogger<WishListController> _logger;
        private readonly WishList _domain;

        public WishListController(WishList domain, ILogger<WishListController> logger )
        {
            _logger = logger;
            _domain = domain;
 
        }


        [HttpGet("/wishList", Name = "GetWishList")]
        
        //Id de persona desde jwt, recuperar wishlist de persona
        /*public ActionResult<WishList> Get()
        {
            var item = _domain.GetByList_code();

            if (item == null)
            {
                return NotFound();
            }

            return item;
        }*/


        //Recuperar correo de persona desde jwt y modificar addproduct
        [HttpPost("/productsList", Name= "addProduct")]
        public IActionResult AddProduct(Product product)
        {
            _domain.AddProduct(product);
            return Ok();
        }

        //Recuperar correo de persona desde jwt y modificar createwishlist/ Validar si hay una lista ligada al usuario
        /*[HttpPost(Name = "CreateWishList")]
        public void Post()
        {
            _domain.CreateWishList();
        }
        */



        [HttpDelete("/wishlists/{List_code}", Name = "DeleteWishList")]
        public void Delete(int List_code)
        {
            _domain.DeleteWishList(List_code);
        }
    }
}