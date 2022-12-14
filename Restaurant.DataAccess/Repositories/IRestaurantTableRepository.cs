using Restaurant.DataAccess.Entities;

namespace Restaurant.DataAccess.Repositories
{
    public interface IRestaurantTableRepository
    {
        Task<RestaurantTable?> GetByIdAsync(int restaurantId, int tableNumer);
        Task<List<RestaurantTable>> GetByRestaurantIdAsync(int restaurantId);
        Task OpenOrder(RestaurantTable table);
        Task CloseOrder(RestaurantTable table);
        Task<List<RestaurantTable>> GetAllAsync();
        Task InsertAsync(RestaurantTable restaurantTable);
    }
}
