using IntegradorEDI2024.Entidades;
using IntegradorEDI2024.Entidades.Enum;

namespace IntegradorEDI2024.Datos.Interfaces
{
    public interface ISportsRepository : IGenericRepository<Sport>
	{
        void Edit(Sport sport);
        bool Exist(Sport sport);
        bool Related(Sport sport);
        int GetQuantity();
		void SaveChanges();

	}
}
