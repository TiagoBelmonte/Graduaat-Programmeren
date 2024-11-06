using Assignment.Core.Helpers;

namespace Assignment.Core.Interfaces
{

    public interface IBaseRepository<T> where T : class
    {
        T GetById(int id);
        PagedList<T> GetAll(QueryStringParameters parameters);
        T? Add(T entity);
        bool Update(T entity);
        bool Delete(T entity);
    }
}