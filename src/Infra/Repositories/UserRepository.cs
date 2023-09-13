using Domain.Entities;
using Domain.Repositories;
using Infra.Data;
using Microsoft.EntityFrameworkCore;

namespace Infra.Repositories
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        private readonly DbSet<User> users;
        public UserRepository(DatabaseContext db) 
            : base(db)
        {
            users = db.Set<User>();
        }

        public async Task<User> GetUserByEmail(string email)
        {
            return await users.AsNoTracking().FirstOrDefaultAsync(u => u.EmailAddress == email);
        }
    }
}