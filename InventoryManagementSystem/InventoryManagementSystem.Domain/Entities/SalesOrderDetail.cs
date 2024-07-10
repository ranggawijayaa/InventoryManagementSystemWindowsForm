namespace InventoryManagementSystem.Domain.Entities
{
    public class SalesOrderDetail
    {
        public int Id { get; set; }
        public int SalesOrderId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }

        public SalesOrder SalesOrder { get; set; }
        public Product Product { get; set; }
    }
}
