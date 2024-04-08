using Backend.Interfaces;
using SmartTrade.Models;
using System;
using System.Collections.Generic;
using System.Linq;

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
            var person = _context.Person
                .Where(person => person.Email == email)
                .FirstOrDefault();

            return person;
        }

        public Person GetByCredentials(string email, string password)
        {
            var person = _context.Person
                .Where(person => person.Email == email && person.Password == password)
                .FirstOrDefault();

            return person;
        }

        public IEnumerable<Person> GetAll()
        {
            return _context.Person.ToList();
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
}