using Backend.Interfaces;
using Microsoft.EntityFrameworkCore;
using SmartTrade.Models;

namespace Backend.Repositories
{
    public class LaterListRepository : ILaterListRepository
    {
        private readonly AppDbContext _context;

        public LaterListRepository(AppDbContext context)
        {
            _context = context;
        }

        public void AddProduct(int Product_code, Client client)
        {
            _context.Entry(client).Reference(x => x.LaterList).Load();
            var laterList = client.LaterList;
            var existsProduct = _context.Products.Where(item => item.Product_code == Product_code).FirstOrDefault();
            if (existsProduct == null)
            {
                throw new ResourceNotFound("product doesn't exists", Product_code);
            }

            _context.ListProducts.Add(new ListProduct { List_code = laterList.List_code, Product_code = Product_code });
            _context.SaveChanges();
        }

        public void DeleteProduct(int Product_code, Client client)
        {
            var laterlist = client.LaterList;
            var productList = _context.ListProducts
                .Where(listProduct => listProduct.Product_code == Product_code && listProduct.List_code == laterlist.List_code)
                .FirstOrDefault();

            if (laterlist != null && productList != null)
            {
                _context.ListProducts.Remove(productList);
                _context.SaveChanges();
            }
        }

        public List<Product> GetProducts(Client client)
        {
            _context.Entry(client).Reference(client => client.LaterList).Load();

            var listCodes = _context.ListProducts
                .Include(lp => lp.Product)
                .Include(lp => lp.Product.Images)
                .Where(lp => lp.List_code == client.LaterList.List_code)
                .ToList();

            return listCodes.Select(lc => lc.Product).ToList();
        }
    }
}