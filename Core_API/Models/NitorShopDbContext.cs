using Microsoft.EntityFrameworkCore;

namespace Core_API.Models
{
    public class NitorShopDbContext:DbContext
    {
        public NitorShopDbContext(DbContextOptions<NitorShopDbContext> options):base(options) 
        {

        }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>() // One Catgory
                        .HasMany(c => c.Products) // HAs Many Products
                        .WithOne(c => c.Category)  // Each Product Has One Category
                        .HasForeignKey(p => p.CategoryUniqueId); // The Foreign Key as CategoryUniqueId


            base.OnModelCreating(modelBuilder);
        }
    }
}
