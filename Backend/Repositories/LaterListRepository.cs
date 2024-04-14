using Backend.Interfaces;
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

        // Este metodo no deberia ser necesario porque todos los clientes tienen una wishList por defecto
        public void Create(string Email)
        {
            var cliente = _context.Client
            .Where(item => item.Email == Email)
            .FirstOrDefault();

            _context.LaterList.Add(cliente.LaterList);
            _context.SaveChanges();
        }

        // Este metodo realmente hace falta? podemos borrarle la lista de deseos a un usuario?
        public void Delete(string Email)
        {
            var cliente = _context.Client
            .Where(item => item.Email == Email)
            .FirstOrDefault();


            if (cliente.LaterList == null) throw new InvalidOperationException();

            _context.LaterList.Remove(cliente.LaterList);
            _context.SaveChanges();
        }

        public void AddProduct(Product product, Client client)
        {
            _context.Entry(client).Reference(x => x.LaterList).Load();
            var laterList = client?.LaterList;

            if (laterList != null)
            {
                var existsProduct = _context.Products.Where(item => item.Product_code == product.Product_code).FirstOrDefault();
                if (existsProduct == null)
                {
                    _context.Products.Add(product);
                    _context.SaveChanges();
                }
                _context.ListProducts.Add(new ListProduct { List_code = laterList.List_code, Product_code = product.Product_code });
                _context.SaveChanges();
            }
        }

        public void DeleteProduct(Product product, Client client)
        {
            var laterlist = client.LaterList;
            var productList = _context.ListProducts
                .Where(listProduct => listProduct.Product_code == product.Product_code && listProduct.List_code == laterlist.List_code)
                .FirstOrDefault();

            if (laterlist != null && productList != null)
            {
                _context.ListProducts.Remove(productList);
                _context.SaveChanges();
            }
        }

        public LaterList? Get(string Email)
        {
            var cliente = _context.Client
            .Where(item => item.Email == Email)
            .FirstOrDefault();
            var laterList = cliente.LaterList;
            return laterList;
        }

        public IEnumerable<LaterList> GetAll()
        {
            return _context.LaterList.ToList();
        }

        public void Set(int List_code, LaterList item)
        {
            var actualLaterList = _context.LaterList
                .Where(item => item.List_code == List_code)
                .FirstOrDefault();
        }ListRepository(AppDbContext context)
        {
            _context = context;
        }
    }
}