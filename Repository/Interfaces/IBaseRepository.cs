using MissysPastrys.Entities;
using System.Linq.Expressions;

namespace MissysPastrys.Repository.Interfaces
{
    public interface IBaseRepository<T> where T : BaseEntity, new()
    {
        T Create(T entity);
        T Get(string id);
        T Get(Expression<Func<T, bool>> expression);
        bool Exists(Expression<Func<T, bool>> expression);
        T Update(T entity);
        void Remove(T entity);
        List<T> GetAll();
        List<T> GetAll(Expression<Func<T, bool>> expression = null);
        List<T> GetAllByIds(List<string> ids);
        IReadOnlyList<T> SelectAll();
        IReadOnlyList<T> SelectAll(Expression<Func<T, bool>> expression = null);
    }
}
