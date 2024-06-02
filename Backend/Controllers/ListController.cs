using Backend.Interfaces;
using Backend.Utils;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Backend.Models;

namespace Backend.Controllers;

[ApiController]
[Route("[controller]")]
public class ListController : ControllerBase
{
    private readonly ILogger<ListController> _logger;

    public ListController(ILogger<ListController> logger)
    {
        _logger = logger;
    }

    private Client GetAuthenticatedClient()
    {
        var token = HttpContext.Request.Cookies["JWTToken"];
        var email = AuthHelpers.GetEmail(token);
        var client = SmartTrade.Singleton.People
            .OfType<Client>()
            .FirstOrDefault(x => x.Email == email)
            ?? throw new ResourceNotFound("Client not found", email);
        return client;
    }

    [Authorize(Roles = "client")]
    [HttpGet("/wishlist")]
    public List<Product> GetWishListProducts()
    {
        var client = GetAuthenticatedClient();
        return client.WishList;
    }

    [Authorize(Roles = "client")]
    [HttpGet("/giftlist")]
    public List<Product> GetGiftListProducts()
    {
        var client = GetAuthenticatedClient();
        return client.GiftList;
    }

    [Authorize(Roles = "client")]
    [HttpGet("/laterlist")]
    public List<Product> GetLaterListProducts()
    {
        var client = GetAuthenticatedClient();
        return client.LaterList;
    }

    [Authorize(Roles = "client")]
    [HttpGet("/cart")]
    public List<Product> GetCartProducts()
    {
        var client = GetAuthenticatedClient();
        return client.ShoppingCart;
    }

    [Authorize(Roles = "client")]
    [HttpPost("/wishlist/{Product_code}")]
    public void AddProductWishlist(int product_code)
    {
        var client = GetAuthenticatedClient();
        client.WishList.Add(SmartTrade.Singleton.GetProduct(product_code));
    }

    [Authorize(Roles = "client")]
    [HttpPost("/giftlist/{Product_code}")]
    public void AddProductGiftlist(int product_code)
    {
        var client = GetAuthenticatedClient();
        client.GiftList.Add(SmartTrade.Singleton.GetProduct(product_code));
    }

    [Authorize(Roles = "client")]
    [HttpPost("/laterlist/{product_code}")]
    public void AddProductLaterList(int product_code, [FromQuery] bool fromCart = false)
    {
        var client = GetAuthenticatedClient();
        if (fromCart)
        {
            client.ShoppingCart.Remove(SmartTrade.Singleton.GetProduct(product_code));
        }
        client.LaterList.Add(SmartTrade.Singleton.GetProduct(product_code));
    }

    [Authorize(Roles = "client")]
    [HttpPost("/cart/{product_code}")]
    public void AddProductShoppingCart(int product_code, [FromQuery] bool fromLater = false)
    {
        var client = GetAuthenticatedClient();
        if (fromLater)
        {
            client.LaterList.Remove(SmartTrade.Singleton.GetProduct(product_code));
        }
        client.ShoppingCart.Add(SmartTrade.Singleton.GetProduct(product_code));
    }

    [Authorize(Roles = "client")]
    [HttpDelete("/wishlist/{Product_code}")]
    public void DeleteProductFromWishlist(int product_code)
    {
        var client = GetAuthenticatedClient();
        client.WishList.Remove(SmartTrade.Singleton.GetProduct(product_code));
    }

    [Authorize(Roles = "client")]
    [HttpDelete("/giftlist/{Product_code}")]
    public void DeleteProductFromGiftlist(int product_code)
    {
        var client = GetAuthenticatedClient();
        client.GiftList.Remove(SmartTrade.Singleton.GetProduct(product_code));
    }

    [Authorize(Roles = "client")]
    [HttpDelete("/laterlist/{product_code}")]
    public void DeleteProductFromLaterList(int product_code)
    {
        var client = GetAuthenticatedClient();
        client.LaterList.Remove(SmartTrade.Singleton.GetProduct(product_code));
    }

    [Authorize(Roles = "client")]
    [HttpDelete("/cart/{product_code}")]
    public void DeleteProductFromShoppingCart(int product_code, [FromQuery] bool all = false)
    {
        var client = GetAuthenticatedClient();
        if (all)
        {
            client.ShoppingCart.RemoveAll(x => x.Product_code == product_code);
        }
        else
        {
            client.ShoppingCart.Remove(SmartTrade.Singleton.GetProduct(product_code));
        }
    }
}