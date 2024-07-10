namespace InventoryManagementSystem.Domain.Entities
{
    public class Product
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Category { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public int SupplierId { get; set; }

        public Supplier Supplier { get; set; }
        public ICollection<PurchaseOrderDetail> PurchaseOrderDetails { get; set; }
        public ICollection<SalesOrderDetail> SalesOrderDetails { get; set; }
        public ICollection<WarehouseProduct> WarehouseProducts { get; set; }
    }
}