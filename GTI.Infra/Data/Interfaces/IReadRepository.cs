using System.Linq.Expressions;

namespace GTI.Infra.Data.Interfaces
{
    public interface IReadRepository<T> where T : class
    {
        IQueryable<T> FindAll();
        IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression);
        bool Any(Expression<Func<T, bool>> expression);
    }
}
