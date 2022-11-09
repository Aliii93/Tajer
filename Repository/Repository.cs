
using Microsoft.EntityFrameworkCore;
using TajerTest.Models;

namespace TajerTest.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly TajerContext _context;
        private readonly DbSet<T> _entities;

        public Repository(TajerContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _entities = context.Set<T>();
        }


        public void Add(T entity)
        {
            _context.Entry(entity).Property("IsActive").CurrentValue = true;
            _context.Entry(entity).Property("IsDeleted").CurrentValue = false;
            _context.Entry(entity).Property("CreatedDate").CurrentValue = DateTime.Now;
            _entities.Add(entity);
        }

        public void Update(T entity)
        {
            _context.Entry(entity).Property("UpdatedDate").CurrentValue = DateTime.Now;
            _context.Entry(entity).Property("IsActive").CurrentValue = true;
            _context.Entry(entity).Property("IsDeleted").CurrentValue = false;
            _context.Entry(entity).Property("CreatedDate").IsModified = false;
            _context.Entry(entity).State = EntityState.Detached;
            _context.Set<T>().Update(entity);
        }

        public void Delete(T entity)
        {
            _context.Entry(entity).Property("UpdatedDate").CurrentValue = DateTime.Now;
            _context.Entry(entity).Property("IsDeleted").CurrentValue = true;
            _context.Entry(entity).Property("CreatedDate").IsModified = false;
            _context.Entry(entity).State = EntityState.Detached;
            _context.Set<T>().Update(entity);
        }
        public IEnumerable<T> FindByCondition(System.Linq.Expressions.Expression<Func<T, bool>> expression)
        {
            return _entities.Where(expression).AsNoTracking();
        }

        public IEnumerable<T> GetAll()
        {
            return _entities.ToList();
        }

        public async Task<bool> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync().ConfigureAwait(false) > 0;
        }
    }
}
