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

        [Authorize(Roles = "client")]
        [HttpPost("/wishlist")]
        public void AddProductWishlist(int Product_code)
        {
            var token = HttpContext.Request.Cookies["JWTToken"];
            var email = AuthHelpers.GetEmail(token);
            var client = _clientRepository.Get(email);
            var exists = _productRepository.Get(Product_code);
            if (exists == null)
            {
                _wishListRepository.AddProduct(Product_code, client);
            }
        }

        [Authorize(Roles = "client")]
        [HttpPost("/laterlist")]
        public void AddProductLaterlist(int Product_code)
        {
            var token = HttpContext.Request.Cookies["JWTToken"];
            var email = AuthHelpers.GetEmail(token);
            var client = _clientRepository.Get(email);
            var exists = _productRepository.Get(Product_code);
            if (exists == null)
            {
                _laterListRepository.AddProduct(Product_code, client);
            }
        }

        [Authorize(Roles = "client")]
        [HttpDelete("/wishlist/{Product_code}")]
        public void DeleteProductFromWishlist(int Product_code)
        {
            var token = HttpContext.Request.Cookies["JWTToken"];
            var email = AuthHelpers.GetEmail(token);
            var client = _clientRepository.Get(email);
            _wishListRepository.DeleteProduct(Product_code, client);
        }

        [Authorize(Roles = "client")]
        [HttpDelete("/laterlist/{Product_code}")]
        public void DeleteProductFromLaterlist(int Product_code)
        {
            var token = HttpContext.Request.Cookies["JWTToken"];
            var email = AuthHelpers.GetEmail(token);
            var client = _clientRepository.Get(email);
            _laterListRepository.DeleteProduct(Product_code, client);
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
    }
}