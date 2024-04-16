using SmartTrade.Models;

namespace Backend.Interfaces
{
    public interface IWishListRepository : IListRepository<WishList,string>
    {
        public List<Product> GetProducts(Person person);
    }
}