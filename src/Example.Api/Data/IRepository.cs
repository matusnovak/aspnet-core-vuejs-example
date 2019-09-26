using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;

namespace Example.Api.Data
{
    public interface IRepository<T> where T : IEntity
    {
        Task Create(T entity);
        Task Update(T entity);
        Task Delete(T entity);
        IQueryable<T> FindBy();
        Task<T> FindById(int id);
        Task<IList<T>> FindAll();
    }
}
