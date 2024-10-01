using IntegradorEDI2024.Datos.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace IntegradorEDI2024.Datos.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly MiDbContext _miDbContext;
        internal DbSet<T> dbSet { get; set; }

        public GenericRepository(MiDbContext miDbContext)
        {
            _miDbContext = miDbContext;
            dbSet = _miDbContext.Set<T>();
        }

        public void Add(T entity)
        {
            try
            {
                _miDbContext.Add(entity);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void Delete(T entity)
        {
            try
            {
                dbSet.Remove(entity);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public T? Get(Expression<Func<T, bool>>? filter = null, string? propertiesName = null, bool tracked = true)
        {
            IQueryable<T> query = dbSet.AsQueryable();
            if (!string.IsNullOrWhiteSpace(propertiesName))
            {
                foreach (var property in propertiesName.Split(',', StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(property);
                }
            }

            if (filter is not null)
            {
                query = query.Where(filter);
            }
            return tracked ? query.FirstOrDefault()
                          : query.AsNoTracking().FirstOrDefault();
        }

        public IEnumerable<T> GetAll(Expression<Func<T, bool>>? filter = null, Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null, string? propertiesName = null)
        {
            IQueryable<T> query = dbSet.AsNoTracking();
            if (!string.IsNullOrWhiteSpace(propertiesName))
            {
                foreach (var property in propertiesName.Split(',', StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(property);
                }
            }
            if (orderBy is not null)
            {
                query = orderBy(query);
            }
            if (filter is not null)
            {
                query = query.Where(filter);
            }
            return query.ToList(); //creo que el error proviene desde la base de datos que no tengo ImageUrl
        }
    }
}
