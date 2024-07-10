namespace InventoryManagementSystem.Domain.Entities
{
    public class SalesOrder
    {
        public int Id { get; set; }
        public DateTime OrderDate { get; set; }
        public string CustomerName { get; set; }
        public string Status { get; set; }

        public ICollection<SalesOrderDetail> SalesOrderDetails { get; set; }
    }
}
