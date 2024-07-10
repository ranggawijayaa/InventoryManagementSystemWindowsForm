using InventoryManagementSystem.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace InventoryManagementSystem.Infrastructure
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<PurchaseOrder> PurchaseOrders { get; set; }
        public DbSet<PurchaseOrderDetail> PurchaseOrderDetails { get; set; }
        public DbSet<SalesOrder> SalesOrders { get; set; }
        public DbSet<SalesOrderDetail> SalesOrderDetails { get; set; }
        public DbSet<Warehouse> Warehouses { get; set; }
        public DbSet<WarehouseProduct> WarehouseProducts { get; set; }
        public DbSet<User> Users { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Product-Supplier relationship
            modelBuilder.Entity<Product>()
                .HasOne(p => p.Supplier)
                .WithMany(s => s.Products)
                .HasForeignKey(p => p.SupplierId);

            // Composite key for WarehouseProduct
            modelBuilder.Entity<WarehouseProduct>()
                .HasKey(wp => new { wp.WarehouseId, wp.ProductId });

            // PurchaseOrder-Supplier relationship
            modelBuilder.Entity<PurchaseOrder>()
                .HasOne(po => po.Supplier)
                .WithMany(s => s.PurchaseOrders)
                .HasForeignKey(po => po.SupplierId);

            // PurchaseOrderDetail-PurchaseOrder relationship
            modelBuilder.Entity<PurchaseOrderDetail>()
                .HasOne(pod => pod.PurchaseOrder)
                .WithMany(po => po.PurchaseOrderDetails)
                .HasForeignKey(pod => pod.PurchaseOrderId);

            // PurchaseOrderDetail-Product relationship
            modelBuilder.Entity<PurchaseOrderDetail>()
                .HasOne(pod => pod.Product)
                .WithMany(p => p.PurchaseOrderDetails)
                .HasForeignKey(pod => pod.ProductId);

            // SalesOrderDetail-SalesOrder relationship
            modelBuilder.Entity<SalesOrderDetail>()
                .HasOne(sod => sod.SalesOrder)
                .WithMany(so => so.SalesOrderDetails)
                .HasForeignKey(sod => sod.SalesOrderId);

            // SalesOrderDetail-Product relationship
            modelBuilder.Entity<SalesOrderDetail>()
                .HasOne(sod => sod.Product)
                .WithMany(p => p.SalesOrderDetails)
                .HasForeignKey(sod => sod.ProductId);

            // WarehouseProduct-Warehouse relationship
            modelBuilder.Entity<WarehouseProduct>()
                .HasOne(wp => wp.Warehouse)
                .WithMany(w => w.WarehouseProducts)
                .HasForeignKey(wp => wp.WarehouseId);

            // WarehouseProduct-Product relationship
            modelBuilder.Entity<WarehouseProduct>()
                .HasOne(wp => wp.Product)
                .WithMany(p => p.WarehouseProducts)
                .HasForeignKey(wp => wp.ProductId);


            base.OnModelCreating(modelBuilder);
        }
    }
}