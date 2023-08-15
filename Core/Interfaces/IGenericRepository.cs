using Core.Entities;
using Core.Specifications;

namespace Core.Interfaces
{
    public interface IGenericRepository<T> where T : BaseEntity
    {
        Task<T> GetByIdAsync(int id);
        Task<IReadOnlyList<T>> ListAllAsync();
        Task<T> GetEntityWithSpecAsync(IBaseSpecification<T> baseSpecification);
        Task<IReadOnlyList<T>> ListAllWithSpecAsync(IBaseSpecification<T> baseSpecification);
        Task<int> CountAsync(IBaseSpecification<T> baseSpecification);
        void Add(T entity);
        void Update(T entity);
        void Remove(T entity);
    }
}