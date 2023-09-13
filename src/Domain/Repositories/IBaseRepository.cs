using Domain.Entities;
using NetDevPack.Data;

namespace Domain.Repositories
{
    public interface IBaseRepository<T> : IRepository<T> where T : BaseEntity
    {
        void Create(T entity);
        void Update(T entity);
        void Delete(T entity);
        Task<List<T>> GetAll();
        Task<T> GetById(Guid id);
    }
}