#pragma warning disable CS8618

using Microsoft.EntityFrameworkCore;
namespace ChefsAndDishes.Models;

public class ORMContext : DbContext
{
    public ORMContext(DbContextOptions options) : base(options){  }

    public DbSet<Product> Products {get; set; }
    public DbSet<Category> Categories {get; set; }
    public DbSet<Association> Associations {get; set; }
}