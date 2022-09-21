using Medicina.CrossCutting.Repository;
using Medicina.Repository.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Medicina.Repository.Database
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected DbSet<T> Query { get; set; }
        protected DbContext Context { get; set; }

        public Repository(MedicinaContext context)
        {
           this.Context = context;
           this.Query = Context.Set<T>();
        }

        public async Task Delete(T entity)
        {
            this.Query.Remove(entity);
            await this.Context.SaveChangesAsync();
        }

        public async Task<IEnumerable<T>> FindAllByCriterio(Expression<Func<T, bool>> expression)
        {
            return await this.Query.Where(expression).ToListAsync();
        }

        public async Task<T> FindOneByCriterio(Expression<Func<T, bool>> expression)
        {
            return await this.Query.FirstOrDefaultAsync(expression);
        }

        public async Task<T> Get(object id)
        {
            return await this.Query.FindAsync(id);
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            return await this.Query.ToListAsync();
        }

        public async Task Save(T entity)
        {
            await this.Query.AddAsync(entity);
            await this.Context.SaveChangesAsync();
        }

        public async Task Update(T entity)
        {
            this.Query.Update(entity);
            await this.Context.SaveChangesAsync();
        }
    }
}
