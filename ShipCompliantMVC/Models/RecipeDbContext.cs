using System.Data.Entity;

namespace ShipCompliantMVC.Models
{
    public class RecipeDbContext : DbContext
    {
        public DbSet<Recipe> Recipes { get; set; }
    }
}