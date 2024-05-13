using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Backend.Database;

public class ListEntity
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int List_code { get; set; }
    public string? Name { get; set; }
    public List<ListProduct> listProducts { get; set; }

    public ListEntity()
    {}
}