using Backend.Models;

namespace Backend.Interfaces
{
    public interface ISalesPersonRepository : EntityRepository<SalesPerson, string>
    {
    }
}