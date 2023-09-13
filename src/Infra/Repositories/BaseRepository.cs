using Domain.Entities;
using Domain.Repositories;
using Infra.Data;
using Microsoft.EntityFrameworkCore;
using NetDevPack.Data;

namespace Infra.Repositories
{
    public class BaseRepository<T> : IBaseRepository<T> where T : BaseEntity
    {
        private readonly DatabaseContext Db;
        private readonly DbSet<T> DbSet;

        public BaseRepository(DatabaseContext db)
        {
            Db = db;
            DbSet = db.Set<T>();
        }
        public IUnitOfWork UnitOfWork => Db;

        public void Create(T entity)
        {
            DbSet.Add(entity);
        }

        public void Delete(T entity)
        {
            DbSet.Remove(entity);
        }

        public void Dispose()
        {
            Db.Dispose();
        }

        public async Task<List<T>> GetAll()
        {
            return await DbSet.AsNoTracking().ToListAsync();
        }

        public async Task<T> GetById(Guid id)
        {
            return await DbSet.AsNoTracking().FirstOrDefaultAsync(q => q.Id == id);
        }

        public void Update(T entity)
        {
            DbSet.Update(entity);
        }
    }
}