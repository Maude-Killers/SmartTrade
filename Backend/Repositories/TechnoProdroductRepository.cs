using Backend.Interfaces;
using SmartTrade.Models;

namespace Backend.Repositories
{
    public class TechnoProductRepository : ITechnoProductRepository
    {
        private readonly AppDbContext _context;

        public TechnoProductRepository(AppDbContext context)
        {
             _context = context;
        }

        public void Delete(int Product_code)
        {
            var targetProduct = _context.TechnoProduct
                .Where(product => product.Product_code == Product_code)
                .FirstOrDefault();

            if (targetProduct == null) throw new InvalidOperationException();

            _context.TechnoProduct.Remove(targetProduct);
            _context.SaveChanges();
        }

        public TechnoProduct? Get(int Product_code)
        {
            var product = _context.TechnoProduct
                .Where(product => product.Product_code == Product_code)
                .FirstOrDefault();

            return product;
        }

        public IEnumerable<TechnoProduct> GetAll()
        {
            return _context.TechnoProduct.ToList();
        }

        public void Create(TechnoProduct product)
        {
            _context.TechnoProduct.Add(product);
            _context.SaveChanges();
        }

        public void Set(int Product_code, TechnoProduct product)
        {
            var actualProduct = _context.TechnoProduct
                .Where(product => product.Product_code == Product_code)
                .FirstOrDefault();

            if (actualProduct == null) throw new InvalidOperationException();

            actualProduct.Name = product.Name;
            actualProduct.Price = product.Price;
            actualProduct.Description = product.Description;
            actualProduct.Features = product.Features;
            actualProduct.Huella = product.Huella;
            actualProduct.Category = product.Category;

            _context.SaveChanges();
        }
    }
}