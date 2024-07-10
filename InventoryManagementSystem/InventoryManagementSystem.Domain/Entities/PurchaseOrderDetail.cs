namespace InventoryManagementSystem.Domain.Entities
{
    public class PurchaseOrderDetail
    {
        public int Id { get; set; }
        public int PurchaseOrderId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }

        public PurchaseOrder PurchaseOrder { get; set; }
        public Product Product { get; set; }
    }
}
