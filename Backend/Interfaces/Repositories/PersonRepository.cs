using SmartTrade.Models;

namespace Backend.Interfaces
{
    public interface IPersonRepository : EntityRepository<Person, string>
    {
    }
}