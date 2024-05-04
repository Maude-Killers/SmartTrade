﻿using Backend.Interfaces;
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
        private readonly IGiftListRepository _giftListRepository;
        private readonly IShoppingCartRepository _shoppingCartRepository;
        private readonly ILaterListRepository _laterListRepository;
        private readonly IClientRepository _clientRepository;
        private readonly IProductRepository _productRepository;

        public ListController(
            IWishListRepository wishListRepository,
            IGiftListRepository giftListRepository,
            IClientRepository clientRepository,
            IShoppingCartRepository shoppingCartRepository,
            ILaterListRepository laterListRepository,
            ILogger<ListController> logger,
            IProductRepository productRepository)
        {
            _logger = logger;
            _wishListRepository = wishListRepository;
            _giftListRepository = giftListRepository;
            _shoppingCartRepository = shoppingCartRepository;
            _laterListRepository = laterListRepository;
            _clientRepository = clientRepository;
            _productRepository = productRepository;
        }

        [Authorize(Roles = "client")]
        [HttpPost("/wishlist/{Product_code}")]
        public void AddProductWishlist(int Product_code)
        {
            var token = HttpContext.Request.Cookies["JWTToken"];
            var email = AuthHelpers.GetEmail(token);
            var useCase = new AddProductToList(_productRepository, _clientRepository, _wishListRepository);
            useCase.AddProduct(email, Product_code);
        }

        [Authorize(Roles = "client")]
        [HttpPost("/giftlist/{Product_code}")]
        public void AddProductGiftlist(int Product_code)
        {
            var token = HttpContext.Request.Cookies["JWTToken"];
            var email = AuthHelpers.GetEmail(token);
            var useCase = new AddProductToList(_productRepository, _clientRepository, _giftListRepository);
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
        [HttpDelete("/giftlist/{Product_code}")]
        public void DeleteProductFromGiftlist(int Product_code)
        {
            var token = HttpContext.Request.Cookies["JWTToken"];
            var email = AuthHelpers.GetEmail(token);
            var useCase = new DeleteProductFromList(_productRepository, _clientRepository, _giftListRepository);
            useCase.DeleteProduct(email, Product_code);
        }

        [Authorize(Roles = "client")]
        [HttpGet("/wishlist")]
        public List<Product> GetWishListProducts()
        {
            var token = HttpContext.Request.Cookies["JWTToken"];
            var email = AuthHelpers.GetEmail(token);
            var useCase = new GetProductFromList(_clientRepository, _wishListRepository);
            var products = useCase.GetProduct(email);
            return products;
        }

        [Authorize(Roles = "client")]
        [HttpGet("/giftlist")]
        public List<Product> GetGiftListProducts()
        {
            var token = HttpContext.Request.Cookies["JWTToken"];
            var email = AuthHelpers.GetEmail(token);
            var useCase = new GetProductFromList(_clientRepository, _giftListRepository);
            var products = useCase.GetProduct(email);
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
        public void AddProductShoppingCart(int product_code, [FromQuery] bool fromLater = false)
        {
            var token = HttpContext.Request.Cookies["JWTToken"];
            var email = AuthHelpers.GetEmail(token);
            var client = _clientRepository.Get(email);
            if (fromLater)
            {
                var useCase = new MoveProduct(_productRepository, _clientRepository, _laterListRepository, _shoppingCartRepository);
                useCase.Execute(email, product_code);
            }
            else
            {
                Product product = _productRepository.Get(product_code);
                _shoppingCartRepository.AddProduct(product, client);
            }
        }

        [Authorize(Roles = "client")]
        [HttpDelete("/cart/{product_code}")]
        public void DeleteProductFromShoppingCart(int product_code, [FromQuery] bool all = false)
        {
            var token = HttpContext.Request.Cookies["JWTToken"];
            var email = AuthHelpers.GetEmail(token);
            var client = _clientRepository.Get(email);
            Product product = _productRepository.Get(product_code);

            if (all)
            {
                _shoppingCartRepository.DeleteProduct(product, client);
            }
            else
            {
                _shoppingCartRepository.DeleteItem(product, client);
            }
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
        [HttpPost("/laterlist/{product_code}")]
        public void AddProductLaterList(int product_code, [FromQuery] bool fromCart = false)
        {
            var token = HttpContext.Request.Cookies["JWTToken"];
            var email = AuthHelpers.GetEmail(token);
            var client = _clientRepository.Get(email);
            if (fromCart)
            {
                var useCase = new MoveProduct(_productRepository, _clientRepository, _shoppingCartRepository, _laterListRepository);
                useCase.Execute(email, product_code);
            }
            else
            {
                Product product = _productRepository.Get(product_code);
                _laterListRepository.AddProduct(product, client);
            }
        }

        [Authorize(Roles = "client")]
        [HttpDelete("/laterlist/{product_code}")]
        public void DeleteProductFromLaterList(int product_code)
        {
            var token = HttpContext.Request.Cookies["JWTToken"];
            var email = AuthHelpers.GetEmail(token);
            var client = _clientRepository.Get(email);
            Product product = _productRepository.Get(product_code);
            _laterListRepository.DeleteProduct(product, client);
        }
    }
}