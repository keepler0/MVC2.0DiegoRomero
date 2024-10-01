using System.Linq.Expressions;

namespace IntegradorEDI2024.Datos.Interfaces
{
    public interface IGenericRepository<T> where T : class
    {
        IEnumerable<T> GetAll(Expression<Func<T, bool>>? filter = null
            , Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null,
            string? propertiesName = null);
        T? Get(Expression<Func<T, bool>>? filter = null
            , string? propertiesName = null, bool tracked = true);
        void Add(T entity);
        void Delete(T entity);

    }
}
