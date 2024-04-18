using Backend.Interfaces;
using Microsoft.EntityFrameworkCore;
using SmartTrade.Models;

namespace Backend.Repositories
{
    public class ProductRepository : IProductRepository<Product>
    {
        private readonly AppDbContext _context;

        public ProductRepository(AppDbContext context)
        {
            _context = context;
        }

        public void Create(Product item)
        {
            throw new NotImplementedException();
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
            throw new NotImplementedException();
        }

        public IEnumerable<Product> Search(string searchTerm)
        {
            return _context.Products.Where(product => product.Name.Contains(searchTerm)).Include(p => p.Images).ToList();
        }
    }
}