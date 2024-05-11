using Backend.Database;
using Backend.Interfaces;
using SmartTrade.Models;

namespace Backend.Repositories;
public class PersonRepository : IPersonRepository
{
    private readonly AppDbContext _context;
    private readonly ClientRepository _clientRepository;

    public PersonRepository(AppDbContext context)
    {
        _context = context;
        _clientRepository = new ClientRepository(context);
    }

    public void Create(Person person)
    {
        PersonEntity personEntity = new PersonEntity
        {
            Email = person.Email,
            FullName = person.FullName,
            Password = person.Password,
            PhoneNumber = person.PhoneNumber,
        };

        _context.Person.Add(personEntity);
        _context.SaveChanges();
    }

    public void Delete(string email)
    {
        var targetPerson = _context.Person
            .Where(person => person.Email == email)
            .FirstOrDefault();

        if (targetPerson == null)
            throw new InvalidOperationException();

        _context.Person.Remove(targetPerson);
        _context.SaveChanges();
    }

    public Person Get(string email)
    {
        throw new NotImplementedException();
    }

    public Person Get(string email, string password)
    {
        PersonEntity personEntity = _context.Person
            .Where(person => person.Email == email && person.Password == password)
            .First() ?? throw new ResourceNotFound("Person not found", (email, password));

        if (personEntity is ClientEntity) return _clientRepository.GetByCredentials(email, password);

        Person person = new Person
        {
            Email = personEntity.Email,
            FullName = personEntity.FullName,
            Password = personEntity.Password,
            PhoneNumber = personEntity.PhoneNumber,
        };

        return person ?? throw new ResourceNotFound("Doesn't exists a person with this credentials", new { email, password });
    }

    public List<Person> GetAll()
    {
        List<PersonEntity> peopleEntity = _context.Person.ToList();
        List<Person> people = new List<Person>();

        peopleEntity.ForEach(pe =>
       {
            people.Add(Get(pe.Email, pe.Password));
       });

       return people;
    }

    public void Update(string email, Person person)
    {
        var actualPerson = _context.Person
            .Where(person => person.Email == email)
            .FirstOrDefault();

        if (actualPerson == null)
            throw new InvalidOperationException();

        actualPerson.Password = person.Password;
        _context.SaveChanges();
    }
}