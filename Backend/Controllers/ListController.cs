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
        private readonly IShoppingCartRepository _shoppingCartRepository;
        private readonly IClientRepository _clientRepository;
        private readonly IProductRepository _productRepository;

        public ListController(
            IWishListRepository wishListRepository,
            ILaterListRepository laterListRepository,
            IClientRepository clientRepository,
            IShoppingCartRepository shoppingCartRepository,
            ILogger<ListController> logger,
            IProductRepository productRepository
        )
        {
            _logger = logger;
            _wishListRepository = wishListRepository;
            _laterListRepository = laterListRepository;
            _shoppingCartRepository = shoppingCartRepository;
            _clientRepository = clientRepository;
            _productRepository = productRepository;
        }

        [Authorize(Roles = "client")]
        [HttpPost("/wishlist")]
        public void AddProductWishlist(Product product)
        {
            var token = HttpContext.Request.Cookies["JWTToken"];
            var email = AuthHelpers.GetEmail(token);
            var client = _clientRepository.Get(email);
            _wishListRepository.AddProduct(product, client);
        }

        [Authorize(Roles = "client")]
        [HttpPost("/laterlist")]
        public void AddProductLaterlist(Product product)
        {
            var token = HttpContext.Request.Cookies["JWTToken"];
            var email = AuthHelpers.GetEmail(token);
            var client = _clientRepository.Get(email);
            _laterListRepository.AddProduct(product, client);
        }

        [Authorize(Roles = "client")]
        [HttpDelete("/wishlist/{List_code}")]
        public void DeleteProductFromWishlist(Product product)
        {
            var token = HttpContext.Request.Cookies["JWTToken"];
            var email = AuthHelpers.GetEmail(token);
            var client = _clientRepository.Get(email);
            _wishListRepository.DeleteProduct(product, client);
        }

        [Authorize(Roles = "client")]
        [HttpDelete("/laterlist/{List_code}")]
        public void DeleteProductFromLaterlist(Product product)
        {
            var token = HttpContext.Request.Cookies["JWTToken"];
            var email = AuthHelpers.GetEmail(token);
            var client = _clientRepository.Get(email);
            _laterListRepository.DeleteProduct(product, client);
        }

        [Authorize(Roles = "client")]
        [HttpGet("/wishlist")]
        public List<Product> GetWishListProducts()
        {
            var token = HttpContext.Request.Cookies["JWTToken"];
            var email = AuthHelpers.GetEmail(token);
            var client = _clientRepository.Get(email);
            var products = _wishListRepository.GetProducts(client);
            return products;
        }

        [Authorize(Roles = "client")]
        [HttpGet("/laterlist")]
        public List<Product> GetLaterListProducts()
        {
            var token = HttpContext.Request.Cookies["JWTToken"];
            var email = AuthHelpers.GetEmail(token);
            var client = _clientRepository.Get(email);
            var products = _laterListRepository.GetProducts(client);
            return products;
        }

        [Authorize(Roles = "client")]
        [HttpGet("/cart")]
        public List<Product> GetCartProducts()
        {
            var token = HttpContext.Request.Cookies["JWTToken"];
            var email = AuthHelpers.GetEmail(token);
            var client = _clientRepository.Get(email);
            var products = _shoppingCartRepository.GetProducts(client);
            return products;
        }

        [Authorize(Roles = "client")]
        [HttpPost("/cart/{product_code}")]
        public void AddProductShoppingCart(int product_code)
        {
            var token = HttpContext.Request.Cookies["JWTToken"];
            var email = AuthHelpers.GetEmail(token);
            var client = _clientRepository.Get(email);
            Product product = _productRepository.Get(product_code);
            _shoppingCartRepository.AddProduct(product, client);
        }

        [Authorize(Roles = "client")]
        [HttpDelete("/cart/{product_code}")]
        public void DeleteProductFromShoppingCart(int product_code)
        {
            var token = HttpContext.Request.Cookies["JWTToken"];
            var email = AuthHelpers.GetEmail(token);
            var client = _clientRepository.Get(email);
            Product product = _productRepository.Get(product_code);
            _shoppingCartRepository.DeleteProduct(product, client);
        }
    }
}