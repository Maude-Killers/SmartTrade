using Backend.Controllers;
using Backend.Interfaces;
using Microsoft.AspNetCore.Mvc;
using SmartTrade.Models;

namespace Backend.Repositories
{
    public class WishListRepository : IWishListRepository
    {
        private readonly AppDbContext _context;
        private readonly ListController _controller;

        public WishListRepository(AppDbContext context, ListController controller)
        {
            _context = context;
            _controller= controller;
        }

        public void Create(WishList item)
        {
            _context.WishList.Add(item);
            _context.SaveChanges();
        }

        public void Delete(WishList item)
        {
            var targetWishList = _context.WishList
                .Where(_item => _item.List_code == item.List_code)
                .FirstOrDefault();

            if (targetWishList == null) throw new InvalidOperationException();

            _context.WishList.Remove(targetWishList);
            _context.SaveChanges();
        }

        public ActionResult<List> Get(string Email)
        {
            //var targetitem = _context.WishList
            //  .Where(_item => _item == _controller.Get())
            //.FirstOrDefault();
            var targetitem= _controller.Get();
            return targetitem;
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