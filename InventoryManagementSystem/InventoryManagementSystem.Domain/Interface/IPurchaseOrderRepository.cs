using InventoryManagementSystem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagementSystem.Domain.Interface
{
    public interface IPurchaseOrderRepository
    {
        Task<IEnumerable<PurchaseOrder>> GetAllPurchaseOrdersAsync();
        Task<PurchaseOrder> GetPurchaseOrderByIdAsync(int id);
        Task AddPurchaseOrderAsync(PurchaseOrder purchaseOrder);
        Task UpdatePurchaseOrderAsync(PurchaseOrder purchaseOrder);
        Task DeletePurchaseOrderAsync(int id);
    }
}
