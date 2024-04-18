using SmartTrade.Models;

namespace Backend.Interfaces
{
    public interface IClientRepository : EntityRepository<Client, string>
    {
    }
}