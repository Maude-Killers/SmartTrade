using Backend.Interfaces;
using Microsoft.AspNetCore.Mvc;
using SmartTrade.Models;

namespace Backend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SalesPersonController : ControllerBase
    {

        private readonly ILogger<SalesPersonController> _logger;
        private readonly SalesPersonEntity _domain;

        public SalesPersonController(SalesPersonEntity domain, ILogger<SalesPersonController> logger)
        {
            _logger = logger;
            _domain = domain;
        }

        [HttpGet(Name = "GetSalesPerson")]
        public IEnumerable<SalesPerson> Get()
        {
            return _domain.GetAll();
        }

        [HttpGet("salesPerson/{Email}", Name = "GetSalesPersonByEmail")]
        public ActionResult<SalesPerson> Get(int Email)
        {
            var salesPerson = _domain.GetById(Email);

            if (salesPerson == null)
            {
                return NotFound();
            }

            return salesPerson;
        }

        [HttpPost(Name = "CreateSalesPerson")]
        public void Post(SalesPerson salesPerson)
        {
            _domain.CreateSalesPerson(salesPerson);
        }

        [HttpPut("/salesPerson/{Email}", Name = "EditSalesPerson")]
        public void Put(int Email, SalesPerson salesPerson)
        {
            _domain.EditSalesPerson(Email, salesPerson);
        }

        [HttpDelete("/salesPerson/{Email}", Name = "DeleteSalesPerson")]
        public void Delete(int Email)
        {
            _domain.DeleteSalesPerson(Email);
        }
    }
}