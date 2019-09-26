using Example.Api.Models;

namespace Example.Api.Data
{
    public class TodoRepository : Repository<Todo>
    {
        public TodoRepository(ApplicationDbContext db) : base(db)
        {
        }
    }
}
