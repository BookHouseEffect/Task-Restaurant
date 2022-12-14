using Microsoft.EntityFrameworkCore;
using Restaurant.DataAccess.Entities;

namespace Restaurant.DataAccess.Repositories.Implementations
{
    public class RestaurantRepository : IRestaurantRepository
    {
        private readonly DatabaseContext _context;
        private const string RestaurantName = "My Sample Restaurant";
        private const int RestaurantNumberOfTables = 30;

        public RestaurantRepository(DatabaseContext context)
        {
            _context = context;
        }

        public async Task<DbRestaurant> GetRestaurantAsync()
        {
            var restaurant = await _context.Restaurants
                .SingleOrDefaultAsync(x => x.RestaurantName.Equals(RestaurantName));

            if (restaurant == null)
            {
                restaurant = new DbRestaurant
                {
                    RestaurantName = RestaurantName,
                    NumberOfTables = RestaurantNumberOfTables
                };
                _context.Restaurants.Add(restaurant);
                await _context.SaveChangesAsync();
            }

            return restaurant;
        }
    }
}
