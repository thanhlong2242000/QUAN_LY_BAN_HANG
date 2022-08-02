using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace BaseRepository
{
    public class BaseRepository<C, T> : IBaseRepository<T> where T : class where C : DbContext
    {
        public C _context;
        public DbSet<T> dbSet;

        public BaseRepository(C context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            dbSet = _context.Set<T>();
        }

        public virtual IQueryable<T> GetAll(Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null)
        {
            IQueryable<T> query = dbSet;
            if (orderBy != null) return orderBy(query);
            return query;
        }

        public IQueryable<T> GetAllIncluding(string[] includes = null)
        {
            if (includes != null && includes.Any())
            {
                var query = dbSet.Include(includes.First());
                return includes.Skip(1).Aggregate(query, (current, include) => current.Include(include));
            }

            return dbSet;
        }

        public IQueryable<T> GetWhere(Expression<Func<T, bool>> predicate,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null)
        {
            var query = dbSet.Where(predicate);
            if (orderBy != null) return orderBy(query);
            return query;
        }

        public virtual IQueryable<T> GetMulti(Expression<Func<T, bool>> predicate, string[] includes = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null)
        {
            //HANDLE INCLUDES FOR ASSOCIATED OBJECTS IF APPLICABLE
            if (includes != null && includes.Any())
            {
                var query = dbSet.Include(includes.First());
                query = includes.Skip(1).Aggregate(query, (current, include) => current.Include(include));
                if (orderBy != null) return orderBy(query.Where(predicate));
                return query.Where(predicate);
            }

            return dbSet.Where(predicate);
        }

        public T GetSingleOrDefault(Expression<Func<T, bool>> filter)
        {
            return dbSet.AsQueryable().Where(filter).SingleOrDefault();
        }

        public T GetFirstOrDefault(Expression<Func<T, bool>> filter, string[] includes = null)
        {
            if (includes != null && includes.Any())
            {
                var query = dbSet.Include(includes.First());
                query = includes.Skip(1).Aggregate(query, (current, include) => current.Include(include));
                return query.AsQueryable().Where(filter).FirstOrDefault();
            }
            return dbSet.Where(filter).FirstOrDefault();
        }

        public async Task<T> FindBy(object key)
        {
            return await _context.Set<T>().FindAsync(key);
        }

        public bool Exists(Expression<Func<T, bool>> predicate)
        {
            return dbSet.AsQueryable().Any(predicate);
        }

        public Task<int> CountAll()
        {
            return dbSet.CountAsync();
        }

        public Task<int> CountWhere(Expression<Func<T, bool>> predicate)
        {
            return dbSet.AsQueryable().CountAsync(predicate);
        }

        public virtual T Add(T entity)
        {
            dbSet.Add(entity);
            return entity;
        }

        public async Task<T> AddAsync(T entity)
        {
            await dbSet.AddAsync(entity);
            return entity;
        }

        public virtual T Update(T entity)
        {
            dbSet.Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;
            return entity;
        }

        public virtual void Delete(T entity)
        {
            if (_context.Entry(entity).State == EntityState.Detached)
            {
                dbSet.Attach(entity);
            }
            dbSet.Remove(entity);
        }
        public virtual void Delete(object id)
        {
            T entityToDelete = dbSet.Find(id);
            Delete(entityToDelete);
        }

        public object AddUser(object user)
        {
            throw new NotImplementedException();
        }
    }
}