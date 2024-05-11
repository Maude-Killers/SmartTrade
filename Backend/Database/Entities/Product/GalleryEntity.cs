using Backend.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Backend.Database;

public class GalleryEntity
{
    [Key]
    public string? Image { get; set; }
    [ForeignKey("Product")]
    public int? Product_code { get; set; }
    public virtual ProductEntity Product { get; set; }
    public Category? Category { get; set; }
    public GalleryEntity() { }
}