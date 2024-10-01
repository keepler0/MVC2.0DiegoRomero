using IntegradorEDI2024.Entidades;
using IntegradorEDI2024.Entidades.Enum;
using System.Linq.Expressions;

namespace IntegradorEDI2024.Servicios.Interfaces
{
    public interface IColorsService
    {
        IEnumerable<Color?> GetAll(Expression<Func<Color, bool>>? filter = null
                           ,Func<IQueryable<Color>, IOrderedQueryable<Color>>? orderBy = null,
                           string? propertiesName = null);
        void Save(Color color);
        void Delete(Color color);
        bool Related(Color color);
        bool Exist(Color color);
        Color? Get(Expression<Func<Color, bool>>? filter = null,
                   string? propertiesName = null,
                   bool tracked = true);
        int GetQuantity();
        //List<Color> GetPaginatedList(int page, int itemsPerPage,Orden orden);
    }
}
