using Restaurant.DataAccess.Entities;
using Restaurant.DataAccess.Repositories;

namespace Restaurant.Domain.Services
{
    public class UserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IRestaurantRepository _restaurantRepository;

        public UserService(
            IUserRepository userRepository, 
            IRestaurantRepository restaurantRepository)
        {
            _userRepository = userRepository;
            _restaurantRepository = restaurantRepository;
        }

        public async Task<DbUser> GetOrCreateUser(Guid userId, string displayName, string userName)
        {
            DbRestaurant restaurant = await this._restaurantRepository.GetRestaurantAsync();

            var user = await this._userRepository.GetUserAsync(userId);
            if (user is null)
            {
                user = new DbUser
                {
                    Id = userId,
                    DisplayName = displayName,
                    UserName = userName,
                    WorkingAtRestaurantId = restaurant.Id,
                    Restaurant = restaurant
                };
                await _userRepository.AddUserAsync(user);
            }
            else
            {
                user.Restaurant = restaurant;
            }
            
            return user;
        }
    }
}
