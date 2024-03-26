using Backend.Interfaces;
using SmartTrade.Models;

namespace Backend.Repositories
{
    public class PersonRepository : IPersonRepository
    {
        private readonly AppDbContext _context;

        public PersonRepository(AppDbContext context)
        {
            _context = context;
        }

        public void Create(Person person)
        {
            _context.Person.Add(person);
            _context.SaveChanges();
        }

        public void Delete(int Email)
        {
            var targetPerson = _context.Person
                .Where(person => person.Email == Email)
                .FirstOrDefault();

            if (targetPerson == null) throw new InvalidOperationException();

            _context.Person.Remove(targetPerson);
            _context.SaveChanges();
        }

        public Person? Get(int Email)
        {
            var person = _context.Person
                .Where(person => person.Email == Email)
                .FirstOrDefault();

            return person;
        }

        public IEnumerable<Person> GetAll()
        {
            return _context.Person.ToList();
        }

        public void Set(int Email, Person person)
        {
            var actualPerson = _context.Person
                .Where(person => person.Email == Email)
                .FirstOrDefault();

            if (actualPerson == null) throw new InvalidOperationException();

            actualPerson.FullName = person.FullName;
            actualPerson.PhoneNumber = person.PhoneNumber;
            _context.SaveChanges();
        }
    }
}