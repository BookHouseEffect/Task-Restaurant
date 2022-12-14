using Restaurant.DataAccess.Entities;

namespace Restaurant.DataAccess.Repositories
{
    public interface ITableOrderRepository
    {
        Task<TableOrder?> GetByIdAsync(int id);
        Task<TableOrder?> GetActiveOrderByTableNumber(int restaurantId, int tableNumber);
        Task CloseOrder(TableOrder order);
        Task<List<TableOrder>> GetAllAsync();
        Task InsertAsync(TableOrder tableOrder);
    }
}
