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

        public void Create(LaterList item)
        {
            _context.WishList.Add(item);
            _context.SaveChanges();
        }

        public void Delete(int List_code)
        {
            var targetLaterList = _context.LaterList
                .Where(item => item.List_code == List_code)
                .FirstOrDefault();

            if (targetLaterList == null) throw new InvalidOperationException();

            _context.WishList.Remove(targetLaterList);
            _context.SaveChanges();
        }

        public LaterList? Get(int List_code)
        {
            var item = _context.LaterList
                .Where(item => item.List_code == List_code)
                .FirstOrDefault();

            return item;
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
        }
    }
}