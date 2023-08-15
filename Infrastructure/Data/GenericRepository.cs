using Core.Entities;
using Core.Interfaces;
using Core.Specifications;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
    {
        private readonly StoreContext _context;
        public GenericRepository(StoreContext context)
        {
            _context = context;
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await _context.Set<T>().FindAsync(id);
        }

        public async Task<IReadOnlyList<T>> ListAllAsync()
        {
            return await _context.Set<T>().ToListAsync();
        }

        public async Task<T> GetEntityWithSpecAsync(IBaseSpecification<T> baseSpecification)
        {
            return await ApplySpecification(baseSpecification).FirstOrDefaultAsync();
        }

        public async Task<IReadOnlyList<T>> ListAllWithSpecAsync(IBaseSpecification<T> baseSpecification)
        {
            return await ApplySpecification(baseSpecification).ToListAsync();
        }

        public async Task<int> CountAsync(IBaseSpecification<T> baseSpecification)
        {
            return await ApplySpecification(baseSpecification).CountAsync();
        }

        public void Add(T entity)
        {
            _context.Set<T>().Add(entity);
        }

        public void Remove(T entity)
        {
            _context.Set<T>().Remove(entity);
        }

        public void Update(T entity)
        {
            _context.Set<T>().Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;
        }




        private IQueryable<T> ApplySpecification(IBaseSpecification<T> baseSpecification)
        {
            return SpecificationEvaluator<T>.GetQuery(_context.Set<T>().AsQueryable(), baseSpecification);
        }
    }
}