using Backend.Interfaces;

namespace SmartTrade.Models
{
    public partial class Person
    {
        private readonly IPersonService _service;

        public Person(IPersonService service)
        {
            _service = service;
        }

        public IEnumerable<Person> GetAll()
        {
            return _service.GetAll();
        }

        public Person? GetById(string Email)
        {
            return _service.Get(Email);
        }

        public void CreatePerson(Person Person)
        {
            _service.Create(Person);
        }

        public void EditPerson(string Email, Person Person)
        {
            _service.Set(Email, Person);
        }

        public void DeletePerson(string Email)
        {
            _service.Delete(Email);
        }

        Person ValidateEmail()
        {
            Person p = _service.Get(Email);
            if (p is SalesPerson sperson)
            {
                return sperson;
            }
            else if (p is Client cperson) { 
                return cperson;
            }
            return null;
        }


    }
}