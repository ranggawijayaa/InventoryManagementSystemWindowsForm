using InventoryManagementSystem.Domain.Entities;
using InventoryManagementSystem.Domain.Interface;
using Microsoft.EntityFrameworkCore;

namespace InventoryManagementSystem.Infrastructure
{
    public class SalesOrderRepository : ISalesOrderRepository
    {
        public readonly ApplicationDbContext _context;

        public SalesOrderRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<SalesOrder>> GetAllSalesOrdersAsync()
        {
            return await _context.SalesOrders.ToListAsync();
        }

        public async Task<SalesOrder> GetSalesOrderByIdAsync(int id)
        {
            return await _context.SalesOrders.FindAsync(id);
        }

        public async Task AddSalesOrderAsync(SalesOrder salesOrder)
        {
            _context.SalesOrders.AddAsync(salesOrder);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateSalesOrderAsync(SalesOrder salesOrder)
        {
            var existingEntity = _context.Products.Local.FirstOrDefault(x => x.Id == salesOrder.Id);
            if (existingEntity != null)
            {
                _context.Entry(existingEntity).State = EntityState.Detached;
            }

            _context.Entry(salesOrder).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteSalesOrderAsync(int id)
        {
            var salesOrder = await _context.SalesOrders.FindAsync(id);
            if (salesOrder != null)
            {
                _context.SalesOrders.Remove(salesOrder);
                await _context.SaveChangesAsync();
            }
        }
    }
}
