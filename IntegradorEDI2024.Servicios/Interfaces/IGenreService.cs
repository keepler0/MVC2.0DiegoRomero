using IntegradorEDI2024.Entidades;
using IntegradorEDI2024.Entidades.Enum;
using System.Linq.Expressions;

namespace IntegradorEDI2024.Servicios.Interfaces
{
    public interface IGenreService
    {
        void Save(Genre genre);
        void Delete(Genre genre);
        IEnumerable<Genre?> GetAll(Expression<Func<Genre, bool>>? filter = null
                          , Func<IQueryable<Genre>, IOrderedQueryable<Genre>>? orderBy = null,
                           string? propertiesName = null);
        bool Exist(Genre genre);
        bool Related(Genre genre);
        Genre? Get(Expression<Func<Genre, bool>>? filter = null,
                   string? propertiesName = null,
                   bool tracked = true);
        Genre? GetGenreByName(string GenreName);
        int GetQuantity();
    }
}
