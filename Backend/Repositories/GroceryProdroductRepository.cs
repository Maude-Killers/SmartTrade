using Backend.Interfaces;
using SmartTrade.Models;

namespace Backend.Repositories
{
    public class GroceryProdroductRepository : ProductRepository, IGroceryProductRepository
    {
        public GroceryProdroductRepository(AppDbContext context) : base(context)
        {
        }

        public void Create(GrocerieProduct product)
        {
            _context.GrocerieProduct.Add(product);
            _context.SaveChanges();
        }

        public void Set(int Product_code, GrocerieProduct product)
        {
            var actualProduct = _context.GrocerieProduct
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