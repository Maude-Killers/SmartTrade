using Backend.Interfaces;
using SmartTrade.Models;

namespace Backend.Repositories
{
    public class SportProductRepository : ProductRepository, ISportProductRepository
    {
        public SportProductRepository(AppDbContext context) : base(context)
        {
        }

        public void Create(SportProduct product)
        {
            _context.SportProduct.Add(product);
            _context.SaveChanges();
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
            actualProduct.Category = product.Category;

            _context.SaveChanges();
        }
    }
}