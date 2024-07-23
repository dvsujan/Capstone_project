using CofeeStoreManagement.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace CofeeStoreManagement.Contexts
{
    public class CofeeStoreManagementContext:DbContext
    {
        public CofeeStoreManagementContext(DbContextOptions options) : base(options)
        {
        }
        

        public DbSet<User> Users { get; set; }
        public DbSet<Store> Stores { get; set; }
        public DbSet<SuperCategory> SuperCategories { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductCategory> ProductCategories { get; set; }
        public DbSet<ProductOption> ProductOptions { get; set; }
        public DbSet<ProductOptionCategory> ProductOptionCategories { get; set; }
        public DbSet<ProductOptionValue> ProductOptionValues { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<CartItem> CartItems { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<Employee> Employees { get; set; }

        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasIndex(u => u.Email)
                .IsUnique();

            modelBuilder.Entity<Employee>()
                .HasIndex(e => e.Email)
                .IsUnique();

            modelBuilder.Entity<Category>()
                .HasOne(c => c.SuperCategory)
                .WithMany(sc => sc.Categories)
                .HasForeignKey(c => c.SuperCategoryId);

            modelBuilder.Entity<ProductCategory>()
                .HasOne(pc => pc.Product)
                .WithMany(p => p.ProductCategories)
                .HasForeignKey(pc => pc.ProductId);

            modelBuilder.Entity<ProductCategory>()
                .HasOne(pc => pc.Category)
                .WithMany(c => c.ProductCategories)
                .HasForeignKey(pc => pc.CategoryId);

            //modelBuilder.Entity<ProductOptionCategory>()
            //    .HasOne(poc => poc.ProductOption)
            //    .WithMany(po => po.ProductOptionValues)
            //    .HasForeignKey(poc => poc.OptionId);

            //modelBuilder.Entity<ProductOptionCategory>()
            //    .HasOne(poc => poc.Category)
            //    .WithMany(c => c.ProductCategories)
            //    .HasForeignKey(poc => poc.CategoryId);

            modelBuilder.Entity<ProductOptionValue>()
                .HasOne(pov => pov.ProductOption)
                .WithMany(po => po.ProductOptionValues)
                .HasForeignKey(pov => pov.OptionId);

            modelBuilder.Entity<Cart>()
                .HasOne(c => c.User)
                .WithMany()
                .HasForeignKey(c => c.UserId);

            modelBuilder.Entity<CartItem>()
                .HasOne(ci => ci.Cart)
                .WithMany(c => c.CartItems)
                .HasForeignKey(ci => ci.CartId);

            modelBuilder.Entity<CartItem>()
                .HasOne(ci => ci.Product)
                .WithMany()
                .HasForeignKey(ci => ci.ProductId);

            modelBuilder.Entity<Order>()
                .HasOne(o => o.User)
                .WithMany()
                .HasForeignKey(o => o.UserId);

            modelBuilder.Entity<Order>()
                .HasOne(o => o.Store)
                .WithMany()
                .HasForeignKey(o => o.StoreId);

            modelBuilder.Entity<OrderItem>()
                .HasOne(oi => oi.Order)
                .WithMany(o => o.OrderItems)
                .HasForeignKey(oi => oi.OrderId);

            modelBuilder.Entity<OrderItem>()
                .HasOne(oi => oi.Product)
                .WithMany()
                .HasForeignKey(oi => oi.ProductId);

            modelBuilder.Entity<Employee>()
                .HasOne(e => e.Store)
                .WithMany()
                .HasForeignKey(e => e.StoreId);
        }

    }
}
