using SmartTrade.Models;

namespace Backend.Interfaces
{
    public interface ILaterListRepository : IListRepository<LaterList,string>
    {
        public List<Product> GetProducts(Person person);
    }
}