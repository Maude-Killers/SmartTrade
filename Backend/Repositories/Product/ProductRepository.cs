using System.Linq;
using Backend.Database;
using Backend.Interfaces;
using Microsoft.EntityFrameworkCore;
using Backend.Models;

namespace Backend.Repositories;
public class ProductRepository : IProductRepository
{
    private readonly AppDbContext _context;
    private readonly IGalleryRepository _galleryRepository;

    public ProductRepository(AppDbContext context)
    {
        _context = context;
        _galleryRepository = new GalleryRepository(context);
    }

    public void Create(Product item)
    {
        if (_context.Products.Any(p => p.Product_code == item.Product_code)) throw new ResourceNotFound("Already exists this product");

        var entity = new ProductEntity
        {
            Category = item.Category,
            Description = item.Description,
            Features = item.Features,
            FingerPrint = item.FingerPrint,
            Name = item.Name,
            Price = item.Price,
            Product_code = item.Product_code,
        };
        _context.Products.Add(entity);

        var gallery = _galleryRepository.CreateGallery(item.Images);
        gallery.ForEach(img => img.Product_code = item.Product_code);
        _context.SaveChanges();
    }

    public void Delete(int id)
    {
        throw new NotImplementedException();
    }

    public Product Get(int id)
    {
        var existsProduct = _context.Products
            .Include(p => p.Gallery)
            .FirstOrDefault(product => product.Product_code == id) ?? throw new ResourceNotFound("product not fount", id);

        var product = new Product
        {
            Category = existsProduct.Category,
            Description = existsProduct.Description,
            Features = existsProduct.Features,
            FingerPrint = existsProduct.FingerPrint,
            Images = existsProduct.Gallery.Select(img => img.Image ?? "").ToList(),
            Name = existsProduct.Name,
            Price = existsProduct.Price,
            Product_code = existsProduct.Product_code,
        };

        return product;
    }

    public List<Product> GetAll()
    {
        var asoka = _context.Products.Include(p => p.Gallery).ToList();
        
        var products = asoka.Select(product => new Product
        {
            Category = product.Category,
            Description = product.Description,
            Features = product.Features,
            FingerPrint = product.FingerPrint,
            Images = product.Gallery.Select(img => img.Image ?? "").ToList(),
            Name = product.Name,
            Price = product.Price,
            Product_code = product.Product_code,
        }).ToList();

        return products;
    }

    public void Set(int id, Product item)
    {
        var oldProduct = _context.Products.Where(product => product.Product_code == id).FirstOrDefault();
        if (oldProduct == null) throw new ResourceNotFound("product not found", id);
        oldProduct.Name = item.Name;
        oldProduct.Price = item.Price;
        oldProduct.Description = item.Description;
        oldProduct.Features = item.Features;
        oldProduct.FingerPrint = item.FingerPrint;
        oldProduct.Category = item.Category;
        _context.SaveChanges();
    }

    public IEnumerable<ProductEntity> Search(string searchTerm)
    {
        return _context.Products
            .Where(product => product.Name.Contains(searchTerm) || product.Description.Contains(searchTerm))
            .Include(p => p.Gallery).ToList();
    }

    public IEnumerable<SportProduct> GetAllSportProducts()
    {
       var listSportProducts = _context.SportProduct.Include(p => p.Gallery).ToList();

       var products = listSportProducts.Select(product => new SportProduct
        {
            Category = product.Category,
            Description = product.Description,
            Features = product.Features,
            FingerPrint = product.FingerPrint,
            Images = product.Gallery.Select(img => img.Image ?? "").ToList(),
            Name = product.Name,
            Price = product.Price,
            Product_code = product.Product_code,
        });

        return products;
    }

    public IEnumerable<TechnoProduct> GetAllTechnoProducts()
    {
        var listTechnoProducts = _context.TechnoProduct.Include(p => p.Gallery).ToList();
       
       var products = listTechnoProducts.Select(product => new TechnoProduct
        {
            Category = product.Category,
            Description = product.Description,
            Features = product.Features,
            FingerPrint = product.FingerPrint,
            Images = product.Gallery.Select(img => img.Image ?? "").ToList(),
            Name = product.Name,
            Price = product.Price,
            Product_code = product.Product_code,
        });

        return products;
    }

    public IEnumerable<GroceryProduct> GetAllGroceryProducts()
    {
        var listGroceryProducts = _context.GroceryProduct.Include(p => p.Gallery).ToList();

       var products = listGroceryProducts.Select(product => new GroceryProduct
        {
            Category = product.Category,
            Description = product.Description,
            Features = product.Features,
            FingerPrint = product.FingerPrint,
            Images = product.Gallery.Select(img => img.Image ?? "").ToList(),
            Name = product.Name,
            Price = product.Price,
            Product_code = product.Product_code,
        });

        return products;
    }
}