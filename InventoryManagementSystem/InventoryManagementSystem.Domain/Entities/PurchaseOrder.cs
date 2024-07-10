namespace InventoryManagementSystem.Domain.Entities
{
    public class PurchaseOrder
    {
        public int Id { get; set; }
        public int SupplierId { get; set; }
        public DateTime OrderDate { get; set; }
        public string Status { get; set; }

        public Supplier Supplier { get; set; }
        public ICollection<PurchaseOrderDetail> PurchaseOrderDetails { get; set; }
    }
}
