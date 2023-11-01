using Business_State_Machine.Models;
using Microsoft.EntityFrameworkCore;

namespace Business_State_Machine.Repositories
{
    public class RepositoryContext : DbContext
    {
        public RepositoryContext(DbContextOptions options) : base(options) { }

        public virtual DbSet<StateTransaction> StateTransactions { get; set; }

    }
}