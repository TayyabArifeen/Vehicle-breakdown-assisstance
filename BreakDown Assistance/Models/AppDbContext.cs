using Glimpse.AspNet.Tab;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BreakDown_Assistance.Models
{
    public class AppDbContext:DbContext
    {
        public AppDbContext()
        {
        }

        public AppDbContext(DbContextOptions options):base(options)
        {

        }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Purchase> Purchases { get; set; }
        public virtual DbSet<PurchaseDetail> PurchaseDetails { get; set; }
        public virtual DbSet<Admin> Admins { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().HasAlternateKey(a => new { a.ProductTitle });
            modelBuilder.Entity<Category>().HasAlternateKey(s => new { s.CategoryTitle });
            modelBuilder.Entity<Purchase>().HasAlternateKey(t => new { t.PurchaseTitle });
            modelBuilder.Entity<PurchaseProduct>()
                .HasOne(c => c.products)
                .WithMany(p => p.purchaseProducts)
                .HasForeignKey(f => f.ProductID)
                .HasPrincipalKey(PK => PK.ProductID);
            modelBuilder.Entity<Product>()
                .HasOne(c => c.Category)
                .WithMany(t => t.products)
                .HasForeignKey(c => c.CategoryID)
                .HasPrincipalKey(t => t.CategoryID);

            modelBuilder.Entity<PurchaseDetail>()
                .HasOne(rc => rc.purchase)
                .WithMany(s => s.purchaseDetails)
                .HasForeignKey(rc => rc.PurchaseID)
                .HasPrincipalKey(s => s.PurchaseID);
            modelBuilder.Entity<PurchaseDetail>()
                .HasOne(p => p.purchaseProduct)
                .WithMany(P => P.purchaseDetails)
                .HasForeignKey(f => f.PurchaseProductID)
                .HasPrincipalKey(Pk => Pk.PurchaseProductID);
        }

        public DbSet<BreakDown_Assistance.Models.PurchaseProduct> PurchaseProduct { get; set; }



    }
}
