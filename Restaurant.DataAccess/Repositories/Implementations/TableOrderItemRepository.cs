using Microsoft.EntityFrameworkCore;
using Restaurant.DataAccess.Entities;

namespace Restaurant.DataAccess.Repositories.Implementations
{
    public class TableOrderItemRepository : ITableOrderItemRepository
    {
        private readonly DatabaseContext _context;

        public TableOrderItemRepository(DatabaseContext context)
        {
            _context = context;
        }

        public async Task<TableOrderItem?> GetByIdAsync(int id)
        {
            return await _context.TableOrderItems.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<TableOrderItem>> GetByTableOrder(int tableOrderId)
        {
            return await _context.TableOrderItems
                .Where(x => x.TableOrderId == tableOrderId)
                .Include(x => x.Product)
                .ToListAsync();
        }

        public async Task<List<TableOrderItem>> GetAllAsync()
        {
            return await _context.TableOrderItems.ToListAsync();
        }

        public async Task InsertAsync(TableOrderItem tableOrderItem)
        {
            await _context.TableOrderItems.AddAsync(tableOrderItem);
            await _context.SaveChangesAsync();
        }
    }
}
