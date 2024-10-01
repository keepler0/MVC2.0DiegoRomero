using IntegradorEDI2024.Entidades;
using IntegradorEDI2024.Entidades.Enum;

namespace IntegradorEDI2024.Datos.Interfaces
{
    public interface IColorsRepository:IGenericRepository<Color>
    {
        void Edit(Color color);
        bool Related(Color color);
        bool Exist(Color color);
        void SaveChanges();
        int GetQuantity();
        //List<Color> GetPaginatedList(int page, int itemsPerPage,Orden orden);
    }
}
