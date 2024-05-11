using Backend.Database;
using Backend.Interfaces;
using Microsoft.EntityFrameworkCore;
using SmartTrade.Models;

namespace Backend.Repositories
{
    public class WishListRepository : IWishListRepository
    {
        private readonly AppDbContext _context;
        private readonly IGalleryRepository _galleryRepository;

        public WishListRepository(AppDbContext context, IGalleryRepository galleryRepository)
        {
            _context = context;
            _galleryRepository = galleryRepository;
        }

        public void AddProduct(Product product, Client client)
        {
            WishListEntity wishlist = _context.Client
                .Where(x => x.Email == client.Email)
                .First().WishList;

            if (wishlist.listProducts.Any(x => x.Product_code == product.Product_code)) throw new ResourceNotFound("product is already in WIshList", product);
            _context.ListProducts.Add(new ListProduct { List_code = wishlist.List_code, Product_code = product.Product_code });
            _context.SaveChanges();
        }

        public void DeleteProduct(Product product, Client client)
        {
            WishListEntity wishlist = _context.Client
                .Where(x => x.Email == client.Email)
                .First().WishList;

            if (!wishlist.listProducts.Any(x => x.Product_code == product.Product_code)) throw new ResourceNotFound("list or productList not found", product);
            _context.ListProducts.Remove(wishlist.listProducts.Where(x => x.Product_code == product.Product_code).First());
            _context.SaveChanges();
        }

        public List<Product> GetProducts(Client client)
        {
            ClientEntity clientEntity = _context.Client
                .Where(x => x.Email == client.Email)
                .First();

            var listCodes = _context.ListProducts
                .Include(lp => lp.Product).ThenInclude(p => p.Gallery)
                .Where(lp => lp.List_code == clientEntity.WishList.List_code)
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
}