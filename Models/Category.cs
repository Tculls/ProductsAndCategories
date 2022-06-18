#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;

public class Category
{
    [Key]
    public int CategoryId {get; set; }

    [Required]
    [MinLength(3, ErrorMessage = "Insert name longer than An")]
    public string Name {get; set; }

    public DateTime CreatedAt {get; set; } = DateTime.Now;
    public DateTime UpdatedAt {get; set; } = DateTime.Now;

    List<Product> Products {get; set; } = new List<Product>();
}