using InventoryManagementSystem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagementSystem.Domain.Interface
{
    public interface ISalesOrderRepository
    {
        Task<IEnumerable<SalesOrder>> GetAllSalesOrdersAsync();
        Task<SalesOrder> GetSalesOrderByIdAsync(int id);
        Task AddSalesOrderAsync(SalesOrder salesOrder);
        Task UpdateSalesOrderAsync(SalesOrder salesOrder);
        Task DeleteSalesOrderAsync(int id);
    }
}
