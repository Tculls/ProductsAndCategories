#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;

public class Product
{
    [Key]

    public int ProductId {get; set; }

    [Required]
    [MinLength(3, ErrorMessage = "Insert a first Name")]
    public string ProductName {get; set; }

    [Required]
    [MinLength(3, ErrorMessage = "Insert a Description")]
    
    public string Description {get; set; }

    [Required]
    [Range(1, 1000000, ErrorMessage = "Insert a Price")]
    [DataType(DataType.Currency)]
    public double? Price {get; set; }

    
    public DateTime CreatedAt {get; set; } = DateTime.Now;
    public DateTime UpdatedAt {get; set; } = DateTime.Now;

    List<Category> Categories {get; set; } = new List<Category>();

    public List<Association> Associations {get; set; } = new List<Association>();
}