using SmartTrade.Models;

namespace Backend.Interfaces
{
    public interface ILaterListRepository : IListRepository<LaterList,string>
    {
        Task<List<ListProduct>> GetProductsAsync(int list_code);
    }
}