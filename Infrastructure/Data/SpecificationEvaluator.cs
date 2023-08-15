using Core.Entities;
using Core.Specifications;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
    public class SpecificationEvaluator<T> where T : BaseEntity
    {
        public static IQueryable<T> GetQuery(IQueryable<T> inputQuery, IBaseSpecification<T> baseSpecification)
        {
           var query = inputQuery;

            if (baseSpecification.Criteria != null)
            {
                query = query.Where(baseSpecification.Criteria);
            }

            if (baseSpecification.OrderBy != null)
            {
                query = query.OrderBy(baseSpecification.OrderBy);
            }

            if (baseSpecification.OrderByDescending != null)
            {
                query = query.OrderByDescending(baseSpecification.OrderByDescending);
            }

            if (baseSpecification.PagingEnabled)
            {
                query = query.Skip(baseSpecification.Skip).Take(baseSpecification.Take);
            }

           query = baseSpecification.Includes.Aggregate(query, (current, include) => current.Include(include));

           return query;
        }
    }
}