using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Backend.Database;

public class LaterListEntity : ListEntity
{
    [ForeignKey("Client")]
    public string ClientEmail { get; set; }
    public virtual ClientEntity Client { get; set; }

    public LaterListEntity() : base()
    {
        Name = "LaterList";
    }
}