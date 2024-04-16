using SmartTrade.Models;

namespace Backend.Interfaces
{
    public interface IWishListService : IListService<WishList, string>
    {
        public List<Product> GetProducts(string email);
    }

}