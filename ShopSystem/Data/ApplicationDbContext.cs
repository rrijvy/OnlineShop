using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ShopSystem.Models;
using OnlineShop.Models;

namespace ShopSystem.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
        }

        public DbSet<OnlineShop.Models.Category> Category { get; set; }

        public DbSet<OnlineShop.Models.Delivery> Delivery { get; set; }

        public DbSet<OnlineShop.Models.DeliveryDetail> DeliveryDetail { get; set; }

        public DbSet<OnlineShop.Models.OrderDetail> OrderDetail { get; set; }

        public DbSet<OnlineShop.Models.Payment> Payment { get; set; }

        public DbSet<OnlineShop.Models.Product> Product { get; set; }

        public DbSet<OnlineShop.Models.ProductImage> ProductImage { get; set; }

        public DbSet<OnlineShop.Models.Purchase> Purchase { get; set; }

        public DbSet<OnlineShop.Models.PurchaseDetail> PurchaseDetail { get; set; }

        public DbSet<OnlineShop.Models.SalesOrder> SalesOrder { get; set; }

        public DbSet<OnlineShop.Models.Supplier> Supplier { get; set; }
    }
}
