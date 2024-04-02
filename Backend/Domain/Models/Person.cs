using System.ComponentModel.DataAnnotations;

namespace SmartTrade.Models
{
    public partial class Person
    {
        [Key]
        public int Email { get; set; }

        public string? FullName { get; set; }

        public int PhoneNumber { get; set; }
    }
}