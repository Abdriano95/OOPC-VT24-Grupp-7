using System.Linq.Expressions;
using System.Security.Cryptography;

namespace Bilverkstad.Datalager.Respositories.BaseRepository
{
    public interface IBaseRepository<T> where T : class, new()
    {
        // Create Read Update Delete (CRUD)

        // Create
        T Add(T entity);
        IEnumerable<T> AddRange(IEnumerable<T> entities);

        // Read
        T Find(int id);
        T FindStringID(string id);
        T FirstOrDefault(Func<T, bool> predicate);
        IEnumerable<T> Find(Func<T, bool> predicate);
        IQueryable<T> GetAll();
        IEnumerable<T> Get(Expression<Func<T, bool>> filter = null!,
                           Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null!,
                           params Expression<Func<T, object>>[] includes);
        IEnumerable<T> Query(Func<IQueryable<T>, IQueryable<T>> query);

        // Update
        void Update(T entity);
        T Update(T oldEntity, T newEntity);
        void UpdatePartial(T existingEntity, Dictionary<string, object> updatedValues);
        void UpdateRange(IEnumerable<T> entities);

        // Delete
        void Delete(int id);
        T Delete(T entity);
        void DeleteRange(IEnumerable<T> entities);
    }
}