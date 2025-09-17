using Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
    public class ECommerceDbContext : DbContext
    {
        public ECommerceDbContext(DbContextOptions<ECommerceDbContext> options)
            : base(options) { }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>(entity =>
            {
                entity.HasKey(c => c.Id);
                entity.Property(c => c.Id).UseIdentityColumn();
                entity.Property(c => c.Name).HasMaxLength(250).IsRequired();
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.HasKey(p => p.Id);
                entity.Property(p => p.Id).UseIdentityColumn();
                entity.Property(p => p.Name).HasMaxLength(100).IsRequired();
                entity.Property(p => p.Price).HasColumnType("decimal(18,2)");
                entity.Property(p => p.Stock).IsRequired();

                
                entity.HasOne(p => p.Category)
                      .WithMany(c => c.Products)
                      .HasForeignKey(p => p.CategoryId)
                      .OnDelete(DeleteBehavior.Cascade);
            });


            // Category Example Data
            modelBuilder.Entity<Category>().HasData(
                new Category { Id = 1, Name = "Taşıt" },
                new Category { Id = 2, Name = "Konut" },
                new Category { Id = 3, Name = "Gıda" }
            );

            // Product Example Data
            modelBuilder.Entity<Product>().HasData(
                new Product { Id = 1, Name = "Binek Araç", Price = 1000000, Stock = 5, CategoryId = 1 },
                new Product { Id = 2, Name = "Ticari Araç", Price = 1500000, Stock = 3, CategoryId = 1 },
                new Product { Id = 3, Name = "3+1 Daire", Price = 3500000, Stock = 1, CategoryId = 2 },
                new Product { Id = 4, Name = "Un", Price = 1000, Stock = 100, CategoryId = 3 }
            );
        }
    }
}
