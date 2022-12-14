using Microsoft.EntityFrameworkCore;
using Restaurant.DataAccess.Entities;

namespace Restaurant.DataAccess.Repositories.Implementations
{
    public class UserRepository : IUserRepository
    {
        private readonly DatabaseContext _context;

        public UserRepository(DatabaseContext context)
        {
            _context = context;
        }

        public async Task<DbUser?> GetUserAsync(Guid guid)
        {
            var user = await this._context.Users.SingleOrDefaultAsync(x => x.Id == guid);

            return user;
        }

        public async Task AddUserAsync(DbUser user)
        {
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
        }
    }
}
