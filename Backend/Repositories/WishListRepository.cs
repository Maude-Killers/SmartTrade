using Backend.Interfaces;
using SmartTrade.Models;

namespace Backend.Repositories
{
    public class WishListRepository : IWishListRepository
    {
        private readonly AppDbContext _context;

        public WishListRepository(AppDbContext context)
        {
            _context = context;
        }

        public void AddProduct(Product product)
        {
            throw new NotImplementedException();
        }

        public void Create(WishList item)
        {
            _context.WishList.Add(item);
            _context.SaveChanges();
        }

        public void Delete(int List_code)
        {
            var targetWishList = _context.WishList
                .Where(item => item.List_code == List_code)
                .FirstOrDefault();

            if (targetWishList == null) throw new InvalidOperationException();

            _context.WishList.Remove(targetWishList);
            _context.SaveChanges();
        }

        public WishList? Get(int List_code)
        {
            var item = _context.WishList
                .Where(item => item.List_code == List_code)
                .FirstOrDefault();

            return item;
        }

        public IEnumerable<WishList> GetAll()
        {
            return _context.WishList.ToList();
        }

        public void Set(int List_code, WishList item)
        {
            var actualWishList = _context.WishList
                .Where(item => item.List_code == List_code)
                .FirstOrDefault();
        }
    }
}