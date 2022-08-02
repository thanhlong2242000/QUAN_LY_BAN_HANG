using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace BaseRepository
{
    public interface IBaseRepository<T> where T : class
    {
        IQueryable<T> GetAll(Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null);
        IQueryable<T> GetAllIncluding(string[] includes = null);

        IQueryable<T> GetWhere(Expression<Func<T, bool>> predicate,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null);

        T GetSingleOrDefault(Expression<Func<T, bool>> filter);
        T GetFirstOrDefault(Expression<Func<T, bool>> filter, string[] includes = null);
        IQueryable<T> GetMulti(Expression<Func<T, bool>> predicate, string[] includes = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null);
        Task<T> FindBy(object key);
        bool Exists(Expression<Func<T, bool>> predicate);

        T Add(T entity);
        Task<T> AddAsync(T entity);
        T Update(T entity);

        Task<int> CountAll();
        Task<int> CountWhere(Expression<Func<T, bool>> predicate);

        void Delete(T entity);
        void Delete(object id);
    }
}