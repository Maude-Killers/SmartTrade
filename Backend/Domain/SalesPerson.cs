using Backend.Interfaces;
using Backend.Services;

namespace SmartTrade.Models
{
    public partial class SalesPersonEntity
    {
        private readonly ISalesPersonService _service;

        public SalesPersonEntity(ISalesPersonService service)
        {
            _service = service;
        }

        public IEnumerable<SalesPerson> GetAll()
        {
            return _service.GetAll();
        }

        public SalesPerson? GetById(int Email)
        {
            return _service.Get(Email);
        }

        public void CreateSalesPerson(SalesPerson salesPerson)
        {
            _service.Create(salesPerson);
        }

        public void EditSalesPerson(int Email, SalesPerson salesPerson)
        {
            _service.Set(Email, salesPerson);
        }

        public void DeleteSalesPerson(int Email)
        {
            _service.Delete(Email);
        }
    }
}