using Domain.Entities;
using Domain.Repositories;
using Infra.Data;
using Microsoft.EntityFrameworkCore;

namespace Infra.Repositories
{
    public class BillRepository : BaseRepository<Bill>, IBillRepository
    {
        private readonly DbSet<Bill> dbSet;
        public BillRepository(DatabaseContext db) : base(db)
        {
           dbSet = db.Set<Bill>();
        }

        public async Task<List<Bill>> GetBillsByUser(Guid userId)
        {
            return await dbSet.AsNoTracking().Where(b => b.UserId == userId).ToListAsync();
        }
    }
}