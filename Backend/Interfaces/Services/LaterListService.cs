using SmartTrade.Models;

namespace Backend.Interfaces
{
    public interface ILaterListService : IListService<LaterList,string>
    {
        public List<Product> GetProducts(string email);
    }

}