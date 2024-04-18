using Backend.Interfaces;
using Microsoft.EntityFrameworkCore;
using SmartTrade.Models;

namespace Backend.Repositories
{
    public class GroceryProductRepository : IGroceryProductRepository
    {
        private readonly AppDbContext _context;

        public GroceryProductRepository(AppDbContext context)
        {
            _context = context;
        }

        public void Delete(int Product_code)
        {
            var targetProduct = _context.GroceryProduct
                .Where(product => product.Product_code == Product_code)
                .FirstOrDefault();

            if (targetProduct == null) throw new InvalidOperationException();

            _context.GroceryProduct.Remove(targetProduct);
            _context.SaveChanges();
        }

        public GroceryProduct Get(int Product_code)
        {
            var product = _context.GroceryProduct.Include(p => p.Images)
            .FirstOrDefault(product => product.Product_code == Product_code);
            return product ?? throw new ResourceNotFound("Grocery product not found", Product_code);
        }

        public IEnumerable<GroceryProduct> GetAll()
        {
            var asoka = _context.GroceryProduct.ToList();
            foreach (var image in asoka)
            {
                _context.GroceryProduct.Include(p => p.Images).ToList();
            }
            return asoka;
        }

        public void Create(GroceryProduct product)
        {
            _context.GroceryProduct.Add(product);
            _context.SaveChanges();
        }

        public void Set(int Product_code, GroceryProduct product)
        {
            var actualProduct = _context.GroceryProduct
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