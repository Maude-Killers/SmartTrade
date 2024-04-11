using Backend.Interfaces;
using SmartTrade.Models;

namespace Backend.Repositories
{
    public class SportProductRepository : ISportProductRepository
    {
        private readonly AppDbContext _context;

        public SportProductRepository(AppDbContext context)
        {
             _context = context;
        }


        public void Create(SportProduct product)
        {
            _context.SportProduct.Add(product);
            _context.SaveChanges();
        }

        public void Delete(int Product_code)
        {
            var targetProduct = _context.SportProduct
                .Where(product => product.Product_code == Product_code)
                .FirstOrDefault();

            if (targetProduct == null) throw new InvalidOperationException();

            _context.SportProduct.Remove(targetProduct);
            _context.SaveChanges();
        }

        public SportProduct? Get(int Product_code)
        {
            var product = _context.SportProduct
                .Where(product => product.Product_code == Product_code)
                .FirstOrDefault();

            return product;
        }

        public IEnumerable<SportProduct> GetAll()
        {
            return _context.SportProduct.ToList();
        }

        public void Set(int Product_code, SportProduct product)
        {
            var actualProduct = _context.SportProduct
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