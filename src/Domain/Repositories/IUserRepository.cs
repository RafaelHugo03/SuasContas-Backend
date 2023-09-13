using Domain.Entities;

namespace Domain.Repositories
{
    public interface IUserRepository : IBaseRepository<User>
    {
        Task<User> GetUserByEmail(string email);
    }
}