using InventoryManagementSystem.Domain.Entities;

namespace InventoryManagementSystem.Domain.Interface
{
    public interface ISupplierRepository
    {
        Task<IEnumerable<Supplier>> GetAllSupplierAsync();
        Task<Supplier> GetSupplierByIdAsync(int id);
        Task AddSupplierAsync(Supplier supplier);
        Task UpdateSupplierAsync(Supplier supplier);
        Task DeleteSupplierAsync(int id);
    }
}
