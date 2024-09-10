using System.Linq.Expressions;

namespace Data.Repositories
{
    public interface IRepository<T> where T : class
    {
        IQueryable<T> GetAll();
        Task<T?> GetByIdAsync(short id);
        Task<T?> GetByIdAsync(int id);
        Task<T?> GetByIdAsync(long id);

        Task<List<T?>> FindAsync(Expression<Func<T, bool>> predicate);
        void Add(T entity);
        void AddRange(IEnumerable<T> entities);
        void Remove(T entity);
        void RemoveRange(IEnumerable<T> entities);
    }
}
