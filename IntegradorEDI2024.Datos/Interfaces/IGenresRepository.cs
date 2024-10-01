using IntegradorEDI2024.Entidades;
using IntegradorEDI2024.Entidades.Enum;

namespace IntegradorEDI2024.Datos.Interfaces
{
    public interface IGenresRepository : IGenericRepository<Genre>
    {
        void Update(Genre genre);
        bool Exist(Genre genre);
        bool Related(Genre genre);
        Genre? GetGenreByName(string GenreName);
        int GetQuantity();
        void SaveChanges();

    }
}
