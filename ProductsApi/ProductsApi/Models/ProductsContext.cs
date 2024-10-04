using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ProductsApi.Models
{
    public class ProductsContext:IdentityDbContext<AppUser,AppRole,int>
    {
        public ProductsContext(DbContextOptions<ProductsContext> options):base (options)
        {

        }
        public DbSet<Products> Products { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Products>().HasData(
                new Products(){ ProductId = 1, ProductName = "IPhone 12", Price = 3333, IsActive = true }
                );
            modelBuilder.Entity<Products>().HasData(
                new Products(){ ProductId = 2, ProductName = "IPhone 13", Price = 4444, IsActive = true }
                );
            modelBuilder.Entity<Products>().HasData(
                new Products(){ ProductId = 3, ProductName = "IPhone 14", Price = 5555, IsActive = false }
                );
            modelBuilder.Entity<Products>().HasData(
                new Products(){ ProductId = 4, ProductName = "IPhone 15", Price = 6666, IsActive = true }
                );
                modelBuilder.Entity<Products>()
                .HasKey(p => p.ProductId); // ProductId anahtar olarak tanımlanıyor.
        } 
    }
    
}