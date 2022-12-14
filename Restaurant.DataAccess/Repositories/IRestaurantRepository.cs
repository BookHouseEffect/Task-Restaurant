using Restaurant.DataAccess.Entities;

namespace Restaurant.DataAccess.Repositories
{
    public interface IRestaurantRepository
    {
        Task<DbRestaurant> GetRestaurantAsync();
    }
}
