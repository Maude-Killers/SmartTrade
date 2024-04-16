using SmartTrade.Models;

namespace Backend.Interfaces
{
    public interface IWishListRepository : IListRepository<WishList,string>
    {
        Task<List<ListProduct>> GetProductsAsync(int list_code);
    }
}