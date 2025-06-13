
using e_commerce_api.Models;
using Microsoft.EntityFrameworkCore;

namespace e_commerce_api.Data
{
    public class ApplicationDbContext : DbContext
    {

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductCategory> Categories { get; set; }
        public DbSet<ProductImage> ProductImages { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Product>(entity =>
            {
                entity.HasIndex(p => p.SKU).IsUnique();

                entity.Property(p => p.SKU).IsRequired().HasMaxLength(50);

                entity.Property(p => p.Name).IsRequired().HasMaxLength(100);

                entity.Property(p => p.Description).HasMaxLength(1000);

                entity.Property(p => p.Price).IsRequired().HasColumnType("decimal(18,2)");

                entity.Property(p => p.Stock).IsRequired();

                entity.Property(p => p.IsActive).IsRequired();

                entity.Property(p => p.CreatedAt).IsRequired();

                entity.Property(p => p.CreatedAt).IsRequired();

                entity.HasOne(p => p.Category)
                    .WithMany(pc => pc.Products)
                    .HasForeignKey(p => p.CategoryId)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<ProductCategory>(entity =>
            {
                entity.Property(pc => pc.Name).IsRequired().HasMaxLength(100);

                entity.Property(pc => pc.Description).HasMaxLength(500);
            });

            modelBuilder.Entity<ProductImage>(entity =>
            {
                entity.Property(pi => pi.Url).IsRequired().HasMaxLength(500);

                entity.Property(pi => pi.AltText).HasMaxLength(255);

                entity.Property(pi => pi.Order).IsRequired();

                entity.HasOne(pi => pi.Product)
                    .WithMany(p => p.Images)
                    .HasForeignKey(pi => pi.ProductId)
                    .OnDelete(DeleteBehavior.Cascade);
            });

        }
    }
}