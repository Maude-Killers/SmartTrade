using Backend.Interfaces;
using SmartTrade.Models;

namespace Backend.Services
{
    public class SalesPersonService : ISalesPersonService
    {
        private readonly ISalesPersonRepository _repository;

        public SalesPersonService(ISalesPersonRepository repository)
        {
            _repository = repository;
        }

        public void Create(SalesPerson item)
        {
            _repository.Create(item);
        }

        public void Delete(int Email)
        {
            _repository.Delete(Email);
        }

        public SalesPerson? Get(int Email)
        {
            return _repository.Get(Email);
        }

        public IEnumerable<SalesPerson> GetAll()
        {
            return _repository.GetAll();
        }

        public void Set(int Email, SalesPerson item)
        {
            _repository.Set(Email, item);
        }
    }
}