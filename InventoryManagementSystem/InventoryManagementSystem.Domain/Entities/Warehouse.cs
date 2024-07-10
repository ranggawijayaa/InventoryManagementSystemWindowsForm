namespace InventoryManagementSystem.Domain.Entities
{
    public class Warehouse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }

        public ICollection<WarehouseProduct> WarehouseProducts { get; set; }
    }
}
