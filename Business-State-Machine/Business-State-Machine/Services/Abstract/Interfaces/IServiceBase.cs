using System.Linq.Expressions;

namespace Business_State_Machine.Services.Abstract.Interfaces
{
    public interface IServiceBase<T> where T : class
    {
        IEnumerable<T> Find(Expression<Func<T, bool>> expression);

        Task<IEnumerable<T>> GetAll(int? page = null);

        Task<T> FindById(int id);

        bool Any(Expression<Func<T, bool>> expression);

        Task<T> FindByProperty<TValue>(Expression<Func<T, TValue>> selector, TValue value);

        Task<T?> NullableFindById(int id);

        Task<T> Delete(int id);

    }
}
