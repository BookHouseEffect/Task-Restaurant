using Restaurant.DataAccess.Entities;

namespace Restaurant.DataAccess.Repositories
{
    public interface IUserRepository
    {
        Task<DbUser?> GetUserAsync(Guid guid);
        Task AddUserAsync(DbUser user);
    }
}
