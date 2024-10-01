using IntegradorEDI2024.Entidades;
using IntegradorEDI2024.Entidades.Enum;
using System.Linq.Expressions;

namespace IntegradorEDI2024.Servicios.Interfaces
{
    public interface IBrandsService
    {
        void Save(Brand brand);
        void Delete(Brand brand);
        IEnumerable<Brand?> GetAll(Expression<Func<Brand, bool>>? filter = null
                          ,Func<IQueryable<Brand>, IOrderedQueryable<Brand>>? orderBy = null,
                           string? propertiesName = null);
        bool Exist(Brand brand);
        bool Related(Brand brand);
        Brand? Get(Expression<Func<Brand, bool>>? filter = null,
                   string? propertiesName = null,
                   bool tracked=true);
        Brand? GetBrandByName(string BrandName);
        int GetQuantity();
        List<Brand> GetPaginatedList(int page,int itemsPerPage,Orden orden);
    }
}
