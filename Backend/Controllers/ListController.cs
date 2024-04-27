using Backend.Interfaces;
using Backend.Repositories;
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
        private readonly ILogger<ListController> _logger;
        private readonly IWishListRepository _wishListRepository;
        private readonly ILaterListRepository _laterListRepository;
        private readonly IClientRepository _clientRepository;
        private readonly IProductRepository _productRepository;

        public ListController(IWishListRepository wishListRepository, ILaterListRepository laterListRepository, IClientRepository clientRepository, ILogger<ListController> logger, IProductRepository productRepository)
        {
            _logger = logger;
            _wishListRepository = wishListRepository;
            _laterListRepository = laterListRepository;
            _clientRepository = clientRepository;
            _productRepository = productRepository;
        }

        [HttpPost("/wishlist")]
        public void AddProductWishlist(int Product_code)
        {
            var token = HttpContext.Request.Cookies["JWTToken"];
            var email = AuthHelpers.GetEmail(token);
            var useCase = new AddProductToList(_productRepository, _clientRepository, _wishListRepository);
            useCase.AddProduct(email, Product_code);
        }

        [Authorize(Roles = "client")]
        [HttpPost("/laterlist")]
        public void AddProductLaterlist(int Product_code)
        {
            var token = HttpContext.Request.Cookies["JWTToken"];
            var email = AuthHelpers.GetEmail(token);
            var useCase = new AddProductToList(_productRepository, _clientRepository, _laterListRepository);
            useCase.AddProduct(email, Product_code);
        }

        [Authorize(Roles = "client")]
        [HttpDelete("/wishlist/{Product_code}")]
        public void DeleteProductFromWishlist(int Product_code)
        {
            var token = HttpContext.Request.Cookies["JWTToken"];
            var email = AuthHelpers.GetEmail(token);
            var useCase = new DeleteProductFromList(_productRepository, _clientRepository, _wishListRepository);
            useCase.DeleteProduct(email, Product_code);
        }

        [Authorize(Roles = "client")]
        [HttpDelete("/laterlist/{Product_code}")]
        public void DeleteProductFromLaterlist(int Product_code)
        {
            var token = HttpContext.Request.Cookies["JWTToken"];
            var email = AuthHelpers.GetEmail(token);
            var useCase = new DeleteProductFromList(_productRepository, _clientRepository, _laterListRepository);
            useCase.DeleteProduct(email, Product_code);
        }

        [Authorize(Roles = "client")]
        [HttpGet("/wishlist")]
        public List<Product> GetWishListProducts()
        {
            var token = HttpContext.Request.Cookies["JWTToken"];
            var email = AuthHelpers.GetEmail(token);
            var useCase = new GetProductFromList(_clientRepository, _wishListRepository);
            var products= useCase.GetProduct(email);
            return products;
        }

        [Authorize(Roles = "client")]
        [HttpGet("/laterlist")]
        public List<Product> GetLaterListProducts()
        {
            var token = HttpContext.Request.Cookies["JWTToken"];
            var email = AuthHelpers.GetEmail(token);
            var useCase = new GetProductFromList(_clientRepository, _laterListRepository);
            var products = useCase.GetProduct(email);
            return products;
        }
    }
}