namespace InventoryManagementSystem.Domain.Entities
{
    public class WarehouseProduct
    {
        public int WarehouseId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }

        public Warehouse Warehouse { get; set; }
        public Product Product { get; set; }
    }
}
