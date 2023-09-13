using Domain.Entities;

namespace Domain.Repositories
{
    public interface IBillRepository : IBaseRepository<Bill>
    {
        Task<List<Bill>> GetBillsByUser(Guid userId);
    }
}