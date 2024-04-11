using Backend.Interfaces;
using SmartTrade.Models;

namespace Backend.Repositories
{
    public class ListRepository : IListRepository
    {
        private readonly AppDbContext _context;

        public ListRepository(AppDbContext context)
        {
            _context = context;
        }

        public void Create(List item)
        {
            _context.List.Add(item);
            _context.SaveChanges();
        }

        public void Delete(int List_code)
        {
            var targetList = _context.List
                .Where(item => item.List_code == List_code)
                .FirstOrDefault();

            if (targetList == null) throw new InvalidOperationException();

            _context.List.Remove(targetList);
            _context.SaveChanges();
        }

        public List? Get(int List_code)
        {
            var item = _context.List
                .Where(item => item.List_code == List_code)
                .FirstOrDefault();

            return item;
        }

        public IEnumerable<List> GetAll()
        {
            return _context.List.ToList();
        }

        public void Set(int List_code, List item)
        {
            var actualList = _context.List
                .Where(item => item.List_code == List_code)
                .FirstOrDefault();
        }
    }
}