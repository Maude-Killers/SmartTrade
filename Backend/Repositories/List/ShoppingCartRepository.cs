using Backend.Database;
using Backend.Interfaces;
using Microsoft.EntityFrameworkCore;
using SmartTrade.Models;

namespace Backend.Repositories;

public class ShoppingCartRepository : IShoppingCartRepository
{
    private readonly AppDbContext _context;
    private readonly IGalleryRepository _galleryRepository;

    public ShoppingCartRepository(AppDbContext context)
    {
        _context = context;
        _galleryRepository = new GalleryRepository(context);
    }

    public void AddProduct(Product product, Client client)
    {
        ShoppingCartEntity shoppingCart = _context.Client
                .Where(x => x.Email == client.Email)
                .First().ShoppingCart;

        if (_context.Products.Any(item => item.Product_code == product.Product_code)) throw new ResourceNotFound("product doesn't exists", product);

        var productInList = shoppingCart.listProducts
            .Where(item => item.Product_code == product.Product_code)
            .FirstOrDefault();

        if (productInList != null)
        {
            productInList.Quantity++;
        }
        else
        {
            _context.ListProducts.Add(new ListProduct { List_code = shoppingCart.List_code, Product_code = product.Product_code });
        }
        _context.SaveChanges();
    }

    public void DeleteProduct(Product product, Client client)
    {
        ShoppingCartEntity shoppingCart = _context.Client
                .Where(x => x.Email == client.Email)
                .First().ShoppingCart;

        var productList = shoppingCart.listProducts
            .Where(listProduct => listProduct.Product_code == product.Product_code)
            .FirstOrDefault();

        if (productList == null) throw new ResourceNotFound("product not found", product);

        _context.ListProducts.Remove(productList);
        _context.SaveChanges();
    }

    public void DeleteItem(Product product, Client client)
    {
        ShoppingCartEntity shoppingCart = _context.Client
                .Where(x => x.Email == client.Email)
                .First().ShoppingCart;

        var productList = _context.ListProducts
            .Where(listProduct => listProduct.Product_code == product.Product_code && listProduct.List_code == shoppingCart.List_code)
            .FirstOrDefault();

        if (productList == null) throw new ResourceNotFound("list or productList not found", product);

        if (productList.Quantity == 1)
        {
            _context.ListProducts.Remove(productList);
        }
        else
        {
            productList.Quantity--;
        }
        _context.SaveChanges();
    }

    public List<Product> GetProducts(Client client)
    {
        ClientEntity clientEntity = _context.Client
                .Where(x => x.Email == client.Email)
                .First();

        var listCodes = _context.ListProducts
            .Include(lp => lp.Product)
            .ThenInclude(p => p.Gallery)
            .Where(lp => lp.List_code == clientEntity.ShoppingCart.List_code)
            .ToList();

        List<Product> listProduct = new List<Product>();

        foreach (var listCode in listCodes)
        {
            for (var i = 0; i < listCode.Quantity; i++)
            {
                listProduct.Add(new Product
                {
                    Product_code = listCode.Product.Product_code,
                    Category = listCode.Product.Category,
                    Description = listCode.Product.Description,
                    Features = listCode.Product.Features,
                    FingerPrint = listCode.Product.FingerPrint,
                    Name = listCode.Product.Name,
                    Price = listCode.Product.Price,
                    Images = _galleryRepository.GetImages((List<GalleryEntity>)listCode.Product.Gallery),
                });
            }
        }

        return listProduct;
    }
}
