using System.ComponentModel.DataAnnotations;

namespace SmartTrade.Models
{
    public partial class Person
    {
        [Key]
        public string Email { get; set; }

        public string Password { get; set; }

        public string? FullName { get; set; }

        public int PhoneNumber { get; set; }

        public Person() {}
    }
}