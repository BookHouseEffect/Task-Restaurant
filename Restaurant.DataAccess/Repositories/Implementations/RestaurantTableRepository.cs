using Microsoft.EntityFrameworkCore;
using Restaurant.DataAccess.Entities;

namespace Restaurant.DataAccess.Repositories.Implementations
{
    public class RestaurantTableRepository : IRestaurantTableRepository
    {
        private readonly DatabaseContext _context;

        public RestaurantTableRepository(DatabaseContext context)
        {
            _context = context;
        }

        public async Task<RestaurantTable?> GetByIdAsync(int restaurantId, int tableNumer)
        {
            return await _context.RestaurantTables.FirstOrDefaultAsync(
                x => x.RestaurantId == restaurantId && x.TableNumber == tableNumer);
        }

        public async Task<List<RestaurantTable>> GetByRestaurantIdAsync(int restaurantId)
        {
            return await _context.RestaurantTables
                .Where(x => x.RestaurantId == restaurantId)
                .ToListAsync();
        }

        public async Task OpenOrder(RestaurantTable table)
        {
            table.HasActiveOrder = true;
            await _context.SaveChangesAsync();
        }

        public async Task CloseOrder(RestaurantTable table)
        {
            table.HasActiveOrder = false;
            await _context.SaveChangesAsync();
        }

        public async Task<List<RestaurantTable>> GetAllAsync()
        {
            return await _context.RestaurantTables.ToListAsync();
        }

        public async Task InsertAsync(RestaurantTable restaurantTable)
        {
            await _context.RestaurantTables.AddAsync(restaurantTable);
            await _context.SaveChangesAsync();
        }
    }
}
