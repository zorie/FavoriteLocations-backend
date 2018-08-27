using System.Linq;

namespace FavLocs.Data.Repositories
{
    public interface IEFRepository<T> where T : class
    {
        IQueryable<T> All { get; }

        T GetById(object id);

        void Add(T entity);

        void Update(T entity);

        void Delete(T entity);
    }
}
