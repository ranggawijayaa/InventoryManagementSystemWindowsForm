using InventoryManagementSystem.Domain;
using Microsoft.EntityFrameworkCore;

namespace InventoryManagementSystem.Infrastructure
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Product> Products { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {            
        }
    }
}