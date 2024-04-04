using Backend.Interfaces;
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

        public void Create(Product product)
        {
            _context.Product.Add(product);
            _context.SaveChanges();
        }

        public void Delete(int Product_code)
        {
            var targetProduct = _context.Product
                .Where(product => product.Product_code == Product_code)
                .FirstOrDefault();

            if (targetProduct == null) throw new InvalidOperationException();

            _context.Product.Remove(targetProduct);
            _context.SaveChanges();
        }

        public Product? Get(int Product_code)
        {
            var product = _context.Product
                .Where(product => product.Product_code == Product_code)
                .FirstOrDefault();

            return product;
        }

        public IEnumerable<Product> GetAll()
        {
            return _context.Product.ToList();
        }

        public void Set(int Product_code, Product product)
        {
            var actualProduct = _context.Product
                .Where(product => product.Product_code == Product_code)
                .FirstOrDefault();

            if (actualProduct == null) throw new InvalidOperationException();

            actualProduct.Name = product.Name;
            actualProduct.Price = product.Price;
            actualProduct.Description = product.Description;
            actualProduct.Features = product.Features;
            actualProduct.Huella = product.Huella;
            _context.SaveChanges();
        }
    }
}