using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Backend.Database;

public class WishListEntity : ListEntity
{
    [ForeignKey("Client")]
    public string ClientEmail { get; set; }
    public virtual ClientEntity Client { get; set; }

    public WishListEntity() : base()
    {
        Name = "WishList";
    }
}