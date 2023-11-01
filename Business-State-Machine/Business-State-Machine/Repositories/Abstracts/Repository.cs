using Business_State_Machine.Repositories.Abstracts.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Business_State_Machine.Repositories.Abstracts
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected readonly DbContext Context;
        public DbSet<T> DBSet { get; }

        public Repository(DbContext context)
        {
            Context = context;
            DBSet = Context.Set<T>();
        }

        public void Dispose() => throw new NotImplementedException();
    }
}
