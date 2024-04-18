using SmartTrade.Models;

namespace Backend.Interfaces
{
    public interface IPersonRepository
    {
        public Person Get(string email);
        public Person Get(string email, string password);
    }
}