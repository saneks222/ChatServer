using System.Linq.Expressions;

namespace ChatServer.Data
{
    public interface IRepository<T> where T : class
    {
        T Get(Expression<Func<T,bool>> filter);
        IList<T> GetList(Expression<Func<T, bool>> filter=null);

        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);

    }
}
