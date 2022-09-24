using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Medicina.CrossCutting.Repository
{
    public interface IRepository<T> where T : class
    {
        Task Save(T entity);
        Task Delete(T entity);
        Task Update(T entity);
        Task<T> Get(object id);
        Task<IEnumerable<T>> GetAll();
        Task<IEnumerable<T>> FindAllByCriterio(Expression<Func<T, bool>> expression);
        Task<T> FindOneByCriterio(Expression<Func<T, bool>> expression);
        ValueTask<bool> AnyAsync(Expression<Func<T, bool>> expression);
        ValueTask<T> GetbyExpressionAsync(Expression<Func<T, bool>> expression);

    }
}
