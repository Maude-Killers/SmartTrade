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
    private readonly SmartTrade _smartTrade;
    private readonly ILogger<ListController> _logger;

    public ListController(SmartTrade smartTrade, ILogger<ListController> logger)
    {
        _smartTrade = smartTrade;
        _logger = logger;
    }

    [Authorize(Roles = "client")]
    [HttpGet("/wishlist")]
    public List<Product> GetWishListProducts()
    {
        var token = HttpContext.Request.Cookies["JWTToken"];
        var email = AuthHelpers.GetEmail(token);
        var client = _smartTrade.People
            .OfType<Client>()
            .FirstOrDefault(x => x.Email == email)
            ?? throw new ResourceNotFound("Client not found", email);

        return client.WishList;
    }

    [Authorize(Roles = "client")]
    [HttpGet("/giftlist")]
    public List<Product> GetGiftListProducts()
    {
        var token = HttpContext.Request.Cookies["JWTToken"];
        var email = AuthHelpers.GetEmail(token);
        var client = _smartTrade.People
            .OfType<Client>()
            .FirstOrDefault(x => x.Email == email)
            ?? throw new ResourceNotFound("Client not found", email);

        return client.GiftList;
    }

    [Authorize(Roles = "client")]
    [HttpGet("/laterlist")]
    public List<Product> GetLaterListProducts()
    {
        var token = HttpContext.Request.Cookies["JWTToken"];
        var email = AuthHelpers.GetEmail(token);
        var client = _smartTrade.People
            .OfType<Client>()
            .FirstOrDefault(x => x.Email == email)
            ?? throw new ResourceNotFound("Client not found", email);

        return client.LaterList;
    }

    [Authorize(Roles = "client")]
    [HttpGet("/cart")]
    public List<Product> GetCartProducts()
    {
        var token = HttpContext.Request.Cookies["JWTToken"];
        var email = AuthHelpers.GetEmail(token);
        var client = _smartTrade.People
            .OfType<Client>()
            .FirstOrDefault(x => x.Email == email)
            ?? throw new ResourceNotFound("Client not found", email);

        return client.ShoppingCart;
    }

    [Authorize(Roles = "client")]
    [HttpPost("/wishlist/{Product_code}")]
    public void AddProductWishlist(int product_code)
    {
        var token = HttpContext.Request.Cookies["JWTToken"];
        var email = AuthHelpers.GetEmail(token);
        var client = _smartTrade.People
            .OfType<Client>()
            .FirstOrDefault(x => x.Email == email)
            ?? throw new ResourceNotFound("Client not found", email);

        client.WishList.Add(_smartTrade.GetProduct(product_code));
    }

    [Authorize(Roles = "client")]
    [HttpPost("/giftlist/{Product_code}")]
    public void AddProductGiftlist(int product_code)
    {
        var token = HttpContext.Request.Cookies["JWTToken"];
        var email = AuthHelpers.GetEmail(token);
        var client = _smartTrade.People
            .OfType<Client>()
            .FirstOrDefault(x => x.Email == email)
            ?? throw new ResourceNotFound("Client not found", email);

        client.GiftList.Add(_smartTrade.GetProduct(product_code));
    }

    [Authorize(Roles = "client")]
    [HttpPost("/laterlist/{product_code}")]
    public void AddProductLaterList(int product_code, [FromQuery] bool fromCart = false)
    {
        var token = HttpContext.Request.Cookies["JWTToken"];
        var email = AuthHelpers.GetEmail(token);
        var client = _smartTrade.People
            .OfType<Client>()
            .FirstOrDefault(x => x.Email == email)
            ?? throw new ResourceNotFound("Client not found", email);

        if (fromCart)
        {
            client.ShoppingCart.Remove(_smartTrade.GetProduct(product_code));
        }
        client.LaterList.Add(_smartTrade.GetProduct(product_code));
    }

    [Authorize(Roles = "client")]
    [HttpPost("/cart/{product_code}")]
    public void AddProductShoppingCart(int product_code, [FromQuery] bool fromLater = false)
    {
        var token = HttpContext.Request.Cookies["JWTToken"];
        var email = AuthHelpers.GetEmail(token);
        var client = _smartTrade.People
            .OfType<Client>()
            .FirstOrDefault(x => x.Email == email)
            ?? throw new ResourceNotFound("Client not found", email);

        if (fromLater)
        {
            client.LaterList.Remove(_smartTrade.GetProduct(product_code));
        }
        client.ShoppingCart.Add(_smartTrade.GetProduct(product_code));
    }

    [Authorize(Roles = "client")]
    [HttpDelete("/wishlist/{Product_code}")]
    public void DeleteProductFromWishlist(int product_code)
    {
        var token = HttpContext.Request.Cookies["JWTToken"];
        var email = AuthHelpers.GetEmail(token);
        var client = _smartTrade.People
            .OfType<Client>()
            .FirstOrDefault(x => x.Email == email)
            ?? throw new ResourceNotFound("Client not found", email);

        client.WishList.Remove(_smartTrade.GetProduct(product_code));
    }

    [Authorize(Roles = "client")]
    [HttpDelete("/giftlist/{Product_code}")]
    public void DeleteProductFromGiftlist(int product_code)
    {
        var token = HttpContext.Request.Cookies["JWTToken"];
        var email = AuthHelpers.GetEmail(token);
        var client = _smartTrade.People
            .OfType<Client>()
            .FirstOrDefault(x => x.Email == email)
            ?? throw new ResourceNotFound("Client not found", email);

        client.GiftList.Remove(_smartTrade.GetProduct(product_code));
    }

    [Authorize(Roles = "client")]
    [HttpDelete("/laterlist/{product_code}")]
    public void DeleteProductFromLaterList(int product_code)
    {
        var token = HttpContext.Request.Cookies["JWTToken"];
        var email = AuthHelpers.GetEmail(token);
        var client = _smartTrade.People
            .OfType<Client>()
            .FirstOrDefault(x => x.Email == email)
            ?? throw new ResourceNotFound("Client not found", email);

        client.LaterList.Remove(_smartTrade.GetProduct(product_code));
    }

    [Authorize(Roles = "client")]
    [HttpDelete("/cart/{product_code}")]
    public void DeleteProductFromShoppingCart(int product_code, [FromQuery] bool all = false)
    {
        var token = HttpContext.Request.Cookies["JWTToken"];
        var email = AuthHelpers.GetEmail(token);
        var client = _smartTrade.People
            .OfType<Client>()
            .FirstOrDefault(x => x.Email == email)
            ?? throw new ResourceNotFound("Client not found", email);

        if (all)
        {
            client.ShoppingCart.RemoveAll(x => x.Product_code == product_code);
        }
        else
        {
            client.ShoppingCart.Remove(_smartTrade.GetProduct(product_code));
        }
    }
}