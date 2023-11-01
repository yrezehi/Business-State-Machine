using Microsoft.EntityFrameworkCore;

namespace Business_State_Machine.Repositories.Abstracts.Interfaces
{
    public interface IRepository<T> : IDisposable where T : class
    {
        public DbSet<T> DBSet { get; }
    }
}
