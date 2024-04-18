using Backend.Interfaces;
using Microsoft.EntityFrameworkCore;
using SmartTrade.Models;

namespace Backend.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly AppDbContext _context;

        public ProductRepository(AppDbContext context)
        {
            _context = context;
        }

        public void Create(Product item)
        {
            _context.Products.Add(item);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Product Get(int id)
        {
            var yoda = _context.Products.Include(p => p.Images).FirstOrDefault(product => product.Product_code == id);
            return yoda ?? throw new ResourceNotFound("product not fount", id);
        }

        public IEnumerable<Product> GetAll()
        {
            var asoka = _context.Products.ToList();
            foreach (var image in asoka)
            {
                _context.Products.Include(p => p.Images).ToList();
            }
            return asoka;
        }

        public void Set(int id, Product item)
        {
            var oldProduct = _context.Products.Where(product => product.Product_code == id).FirstOrDefault();
            if (oldProduct == null) throw new ResourceNotFound("product not found", id);
            oldProduct.Name = item.Name;
            oldProduct.Price = item.Price;
            oldProduct.Description = item.Description;
            oldProduct.Features = item.Features;
            oldProduct.Huella = item.Huella;
            oldProduct.Category = item.Category;
            _context.SaveChanges();
        }

        public IEnumerable<Product> Search(string searchTerm)
        {
            return _context.Products.Where(product => product.Name.Contains(searchTerm)).Include(p => p.Images).ToList();
        }

        public IEnumerable<SportProduct> GetAllSportProducts()
        {
            var asoka = _context.SportProduct.ToList();
            foreach (var image in asoka)
            {
                _context.Products.Include(p => p.Images).ToList();
            }
            return asoka;
        }

        public IEnumerable<TechnoProduct> GetAllTechnoProducts()
        {
            var asoka = _context.TechnoProduct.ToList();
            foreach (var image in asoka)
            {
                _context.Products.Include(p => p.Images).ToList();
            }
            return asoka;
        }

        public IEnumerable<GroceryProduct> GetAllGroceryProducts()
        {
            var asoka = _context.GroceryProduct.ToList();
            foreach (var image in asoka)
            {
                _context.Products.Include(p => p.Images).ToList();
            }
            return asoka;
        }
    }
}