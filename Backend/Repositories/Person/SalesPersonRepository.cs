using Backend.Interfaces;
using SmartTrade.Models;

namespace Backend.Repositories
{
    public class SalesPersonRepository : ISalesPersonRepository
    {
        private readonly AppDbContext _context;

        public SalesPersonRepository(AppDbContext context)
        {
            _context = context;
        }

        public void Create(SalesPerson salesPerson)
        {
            _context.SalesPerson.Add(salesPerson);
            _context.SaveChanges();
        }

        public void Delete(string Email)
        {
            var targetSalesPerson = _context.SalesPerson
                .Where(salesPerson => salesPerson.Email == Email)
                .FirstOrDefault();

            if (targetSalesPerson == null) throw new InvalidOperationException();

            _context.SalesPerson.Remove(targetSalesPerson);
            _context.SaveChanges();
        }

        public SalesPerson Get(string Email)
        {
            var salesPerson = _context.SalesPerson
                .Where(salesPerson => salesPerson.Email == Email)
                .FirstOrDefault();

            return salesPerson ?? throw new ResourceNotFound("Sales person not found", Email);
        }

        public SalesPerson? GetByCredentials(string Email, string Password)
        {
            var salesPerson = _context.SalesPerson
                .Where(salesPerson => salesPerson.Email == Email && salesPerson.Password == Password)
                .FirstOrDefault();

            return salesPerson;
        }

        public IEnumerable<SalesPerson> GetAll()
        {
            return _context.SalesPerson.ToList();
        }

        public void Set(string Email, SalesPerson salesPerson)
        {
            var actualSalesPerson = _context.SalesPerson
                .Where(salesPerson => salesPerson.Email == Email)
                .FirstOrDefault();

            if (actualSalesPerson == null) throw new InvalidOperationException();

            actualSalesPerson.Password = salesPerson.Password;
            actualSalesPerson.Company = salesPerson.Company;
            _context.SaveChanges();
        }
    }
}