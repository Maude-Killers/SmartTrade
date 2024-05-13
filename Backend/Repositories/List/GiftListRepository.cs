using Backend.Database;
using Backend.Interfaces;
using Microsoft.EntityFrameworkCore;
using Backend.Models;

namespace Backend.Repositories;
public class GiftListRepository : IGiftListRepository
{
    private readonly AppDbContext _context;
    private readonly IGalleryRepository _galleryRepository;

    public GiftListRepository(AppDbContext context)
    {
        _context = context;
        _galleryRepository = new GalleryRepository(context);
    }

    public void AddProduct(Product product, Client client)
    {
        GiftListEntity giftList = _context.Client
                .Where(x => x.Email == client.Email)
                .First().GiftList;

        if (giftList.listProducts.Any(x => x.Product_code == product.Product_code)) throw new ResourceNotFound("product is already in GiftList", product);
        _context.ListProducts.Add(new ListProduct { List_code = giftList.List_code, Product_code = product.Product_code });
        _context.SaveChanges();
    }

    public void DeleteProduct(Product product, Client client)
    {
        GiftListEntity giftList = _context.Client
                .Where(x => x.Email == client.Email)
                .First().GiftList;

        if (!giftList.listProducts.Any(x => x.Product_code == product.Product_code)) throw new ResourceNotFound("list or productList not found", product);
        _context.ListProducts.Remove(giftList.listProducts.Where(x => x.Product_code == product.Product_code).First());
        _context.SaveChanges();
    }

    public List<Product> GetProducts(Client client)
    {
        ClientEntity clientEntity = _context.Client
                .Where(x => x.Email == client.Email)
                .First();

        var listCodes = _context.ListProducts
            .Include(lp => lp.Product).ThenInclude(p => p.Gallery)
            .Where(lp => lp.List_code == clientEntity.GiftList.List_code)
            .ToList();

        return listCodes.Select(lc => lc.Product)
            .Select(x => new Product
            {
                Product_code = x.Product_code,
                Category = x.Category,
                Description = x.Description,
                Features = x.Features,
                FingerPrint = x.FingerPrint,
                Name = x.Name,
                Price = x.Price,
                Images = _galleryRepository.GetImages((List<GalleryEntity>)x.Gallery),
            }).ToList();
    }
}