using System.Collections;
using System.Linq.Expressions;

namespace TajerTest.Repository
{
    public interface IRepository<T>
    {
        IEnumerable<T> GetAll();
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
        Task<bool> SaveChangesAsync();
        IEnumerable<T> FindByCondition(Expression<Func<T, bool>> expression);
    }
}
