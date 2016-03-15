using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using TCDBEntities;

namespace TCRepositories
{
    //The Generic Interface Repository for Performing Read/Add/Delete operations
    public interface IGenericRepository<TEntity> : IDisposable
    { 
        //IQueryable<TEntity> SearchFor(Expression<Func<TEntity, bool>> predicate);

        IQueryable<TEntity> GetAll();

        TEntity GetById(int id);

        int Insert(TEntity entity);

        int Update(TEntity entity);

        int Delete(int id);        
    }

    public interface IGenericAsyncRepository<TEntity> : IDisposable
    {
        Task<TEntity> GetByIdAsync(int id);

        Task UpdateAsync(TEntity entity);

        Task InsertAsync(TEntity entity);

        Task DeleteAsync(TEntity entity);
    }

    public class GenericRepository<TEntity> : IGenericRepository<TEntity>, IGenericAsyncRepository<TEntity> where TEntity : class
    {

        protected DbSet<TEntity> DbSet;
      
        private readonly DbContext _dbContext;

        public GenericRepository(DbContext dbContext)
        {
            _dbContext = dbContext;
            DbSet = _dbContext.Set<TEntity>();
        }
        
        public GenericRepository()
        {

        }

        public IQueryable<TEntity> GetAll()
        {
            return DbSet;
        }

        public TEntity GetById(int id)
        {
            return DbSet.Find(id);
        }

        public async Task<TEntity> GetByIdAsync(int id)
        {
            return await DbSet.FindAsync(id);
        }

        public IQueryable<TEntity> SearchFor(Expression<Func<TEntity, bool>> predicate)
        {
            return DbSet.Where(predicate);
        }

        public int Insert(TEntity entity)
        {
            DbSet.Add(entity);
            return _dbContext.SaveChanges();
        }

        public int Update(TEntity entity)
        {
            _dbContext.Entry(entity).State = EntityState.Modified;
            return _dbContext.SaveChanges();
        }

        public int Delete(int id)
        {
            TEntity entity = DbSet.Find(id);
            DbSet.Remove(entity);
            return _dbContext.SaveChanges();
        }


        public async Task UpdateAsync(TEntity entity)
        {
            _dbContext.Entry(entity).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }

        public async Task InsertAsync(TEntity entity)
        {
            DbSet.Add(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(TEntity entity)
        {
            DbSet.Remove(entity);
            await _dbContext.SaveChangesAsync();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _dbContext.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
