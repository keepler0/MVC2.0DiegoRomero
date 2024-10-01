using IntegradorEDI2024.Entidades;
using IntegradorEDI2024.Entidades.Enum;

namespace IntegradorEDI2024.Datos.Interfaces
{
    public interface IBrandsRepository:IGenericRepository<Brand>
    {
        void Edit(Brand brand);
        bool Exist(Brand brand);
        bool Related(Brand brand);
        Brand? GetBrandByName(string BrandName);
        void SaveChanges();
        int GetQuantity();
        //List<Brand> GetPaginatedList(int page, int itemsPerPage,Orden orden);
    }
}
