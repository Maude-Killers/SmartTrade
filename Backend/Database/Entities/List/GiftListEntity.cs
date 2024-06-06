using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Backend.Database;

public class GiftListEntity : ListEntity
{
    [ForeignKey("Client")]
    public string ClientEmail { get; set; }
    public virtual ClientEntity Client { get; set; }
    public GiftListEntity() : base()
    {
        Name = "GiftList";
    }
}