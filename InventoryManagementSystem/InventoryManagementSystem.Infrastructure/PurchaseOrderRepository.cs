using InventoryManagementSystem.Domain.Entities;
using InventoryManagementSystem.Domain.Interface;
using Microsoft.EntityFrameworkCore;

namespace InventoryManagementSystem.Infrastructure
{
    public class PurchaseOrderRepository : IPurchaseOrderRepository
    {
        public readonly ApplicationDbContext _context;

        public PurchaseOrderRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<PurchaseOrder>> GetAllPurchaseOrdersAsync()
        {
            return await _context.PurchaseOrders.ToListAsync();
        }

        public async Task<PurchaseOrder> GetPurchaseOrderByIdAsync(int id)
        {
            return await _context.PurchaseOrders.FindAsync(id);
        }

        public async Task AddPurchaseOrderAsync(PurchaseOrder purchaseOrder)
        {
            _context.PurchaseOrders.AddAsync(purchaseOrder);
            await _context.SaveChangesAsync();
        }

        public async Task UpdatePurchaseOrderAsync(PurchaseOrder purchaseOrder)
        {
            var existingEntity = _context.Products.Local.FirstOrDefault(x => x.Id == purchaseOrder.Id);
            if (existingEntity != null)
            {
                _context.Entry(existingEntity).State = EntityState.Detached;
            }

            _context.Entry(purchaseOrder).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeletePurchaseOrderAsync(int id)
        {
            var purchaseOrder = await _context.PurchaseOrders.FindAsync(id);
            if (purchaseOrder != null)
            {
                _context.PurchaseOrders.Remove(purchaseOrder);
                await _context.SaveChangesAsync();
            }
        }
    }
}
