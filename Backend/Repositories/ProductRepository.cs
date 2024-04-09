using Backend.Interfaces;
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

        public Product? Get(int id)
        {
            return _context.Products.Where(product => product.Product_code == id).FirstOrDefault();
        }

        public IEnumerable<Product> GetAll()
        {
            return _context.Products.ToList();
        }

        public void Set(int id, Product item)
        {
            throw new NotImplementedException();
        }
    }
}