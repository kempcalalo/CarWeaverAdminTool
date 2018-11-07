using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using CarWeaverAdminTool.Data.Interfaces;

namespace CarWeaverAdminTool.Data.Repository
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
    {
        internal CarWeaverAdminToolAppContext Context;
        internal DbSet<TEntity> DbSet;

        public GenericRepository(CarWeaverAdminToolAppContext context)
        {
            this.Context = context;
            this.DbSet = context.Set<TEntity>();
        }
        public async Task<IEnumerable<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> filter = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, string includeProperties = "")
        {
            IQueryable<TEntity> query = DbSet;
            if (filter != null)
            {
                query = query.Where(filter);
            }
            query = includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries).Aggregate(query, (current, includeProperty) => current.Include(includeProperty));
            return orderBy != null ? await orderBy(query).ToListAsync() : await query.ToListAsync();
        }

        public async Task<TEntity> GetByIdAsync(object id)
        {
            return await DbSet.FindAsync(id);
        }

        public void Insert(TEntity entity)
        {
            DbSet.Add(entity);
        }

        public void DeleteById(object id)
        {
            var entityToDelete = DbSet.Find(id);
            Delete(entityToDelete);
        }

        public void Delete(TEntity entity)
        {
            SetDbEntityEntrySafely(entity);
            DbSet.Remove(entity);
        }

        public void Update(TEntity entity)
        {
            SetDbEntityEntrySafely(entity);
            Context.Entry(entity).State = EntityState.Modified;
        }

        #region Private Methods
        private void SetDbEntityEntrySafely(TEntity entity)
        {
            if (Context.Entry(entity).State == EntityState.Detached)
            {
                DbSet.Attach(entity);
            }
        }
        #endregion
    }
}
