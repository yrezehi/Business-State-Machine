using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using Business_State_Machine.Services.Abstract.Interfaces;
using Business_State_Machine.Repositories.Abstracts.Interfaces;

namespace Business_State_Machine.Services.Abstract
{
    public class ServiceBase<T> : IServiceBase<T> where T : class
    {
        public ServiceBase(IUnitOfWork unitOfWork) =>
            (DBSet, UnitOfWork) = (unitOfWork.Repository<T>().DBSet, unitOfWork);

        protected internal IUnitOfWork UnitOfWork { get; set; }
        protected DbSet<T> DBSet { get; set; }

        private static int DEFAULT_PAGE_SIZE = 10;

        public virtual IEnumerable<T> Find(Expression<Func<T, bool>> expression) =>
            DBSet.Where(expression);

        public virtual bool Any(Expression<Func<T, bool>> expression) =>
            DBSet.Any(expression);

        public virtual async Task<int> Count(Expression<Func<T, bool>>? expression = null) =>
            await (expression != null ? DBSet.CountAsync(expression) : DBSet.CountAsync());

        public virtual IQueryable<T> OrderBy<TValue>(Expression<Func<T, TValue>> orderByExpression) =>
            DBSet.OrderBy(orderByExpression);

        public virtual async Task<IEnumerable<T>> GetAll(int? page = null) =>
            await DBSet.ToListAsync();

        public async Task<T> FindByProperty<TValue>(Expression<Func<T, TValue>> selector, TValue value)
        {
            var predicate = Expression.Lambda<Func<T, bool>>(Expression.Equal(selector.Body, Expression.Constant(value, typeof(TValue))), selector.Parameters);

            T? entity = await DBSet.FirstOrDefaultAsync(predicate);

            if (entity == null)
                throw new ArgumentException($"Find by property was not found!");

            return entity;
        }

        public async Task<IEnumerable<T>> FindAllByProperty<TValue>(Expression<Func<T, TValue>> selector, TValue value)
        {
            var predicate = Expression.Lambda<Func<T, bool>>(Expression.Equal(selector.Body, Expression.Constant(value, typeof(TValue))), selector.Parameters);

            IEnumerable<T> entites = await DBSet.Where(predicate).ToListAsync();

            if (!entites.Any())
                throw new ArgumentException($"Find all by property was not found!");

            return entites;
        }

        public virtual async Task<T> FindById(int id)
        {
            var entity = await DBSet.FindAsync(id);

            if (entity == null)
                throw new ArgumentException("Entity Not Found");

            return entity;
        }

        public virtual async Task<T?> NullableFindById(int id) =>
            await DBSet.FindAsync(id);


        public virtual async Task<T> Delete(int id)
        {
            var targetEntitiy = await DBSet.FindAsync(id);

            if (targetEntitiy != null)
            {
                DBSet.Remove(targetEntitiy);

                return targetEntitiy;
            }

            throw new ArgumentException("No id found to be deleted!");
        }

    }
}
