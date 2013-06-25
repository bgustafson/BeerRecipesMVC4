using System.Data.Entity;

namespace ShipCompliantMVC.Models
{
    public class IngredientDbContext : DbContext
    {
        public DbSet<Ingredient> Ingredients { get; set; }
    }
}