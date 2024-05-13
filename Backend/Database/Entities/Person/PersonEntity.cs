using System.ComponentModel.DataAnnotations;

namespace Backend.Database;

public class PersonEntity
{
    [Key]
    public string Email { get; set; }

    public string Password { get; set; }

    public string? FullName { get; set; }

    public int PhoneNumber { get; set; }

    public PersonEntity() { }
}