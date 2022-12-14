using Restaurant.DataAccess.Entities;

namespace Restaurant.DataAccess.Repositories
{
    public interface ITableOrderItemRepository
    {
        Task<TableOrderItem?> GetByIdAsync(int id);
        Task<List<TableOrderItem>> GetByTableOrder(int tableOrderId);
        Task<List<TableOrderItem>> GetAllAsync();
        Task InsertAsync(TableOrderItem tableOrderItem);
    }
}
