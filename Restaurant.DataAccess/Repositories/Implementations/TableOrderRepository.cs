using Microsoft.EntityFrameworkCore;
using Restaurant.DataAccess.Entities;

namespace Restaurant.DataAccess.Repositories.Implementations
{
    public class TableOrderRepository : ITableOrderRepository
    {
        private readonly DatabaseContext _context;

        public TableOrderRepository(DatabaseContext context)
        {
            _context = context;
        }

        public async Task<TableOrder?> GetByIdAsync(int id)
        {
            return await _context.TableOrders.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<TableOrder?> GetActiveOrderByTableNumber(int restaurantId, int tableNumber)
        {
            return await _context.TableOrders.Where(
                x => x.RestaurantId == restaurantId && x.TableNumber == tableNumber && !x.ClosedOrder)
                .Include(x => x.User)
                .FirstOrDefaultAsync();
        }

        public async Task CloseOrder(TableOrder order)
        {
            order.ClosedOrder = true;
            await _context.SaveChangesAsync();
        }

        public async Task<List<TableOrder>> GetAllAsync()
        {
            return await _context.TableOrders.ToListAsync();
        }

        public async Task InsertAsync(TableOrder tableOrder)
        {
            await _context.TableOrders.AddAsync(tableOrder);
            await _context.SaveChangesAsync();
        }
    }
}
