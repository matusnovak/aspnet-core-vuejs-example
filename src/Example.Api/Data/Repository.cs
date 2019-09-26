using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Example.Api.Data
{
    public class Repository<T> : IRepository<T> where T : class, IEntity
    {
        protected readonly ApplicationDbContext db;

        public Repository(ApplicationDbContext db)
        {
            this.db = db;
        }

        public async Task Create(T entity)
        {
            db.Set<T>().Add(entity);
            await db.SaveChangesAsync().ConfigureAwait(false);
        }

        public async Task Delete(T entity)
        {
            db.Set<T>().Remove(entity);
            await db.SaveChangesAsync().ConfigureAwait(false);
        }

        public IQueryable<T> FindBy()
        {
            return db.Set<T>();
        }

        public async Task<T> FindById(int id)
        {
            return await db.Set<T>().FindAsync(id).ConfigureAwait(false);
        }

        public async Task<IList<T>> FindAll()
        {
            return await db.Set<T>().ToListAsync().ConfigureAwait(false);
        }

        public async Task Update(T entity)
        {
            db.Entry(entity).State = EntityState.Modified;
            await db.SaveChangesAsync().ConfigureAwait(false);
        }
    }
}
