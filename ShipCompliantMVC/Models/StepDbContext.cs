using System.Data.Entity;

namespace ShipCompliantMVC.Models
{
    public class StepDbContext : DbContext
    {
        public DbSet<Step> Steps { get; set; }
    }
}