using IntegradorEDI2024.Entidades;
using IntegradorEDI2024.Entidades.Enum;
using System.Linq.Expressions;

namespace IntegradorEDI2024.Servicios.Interfaces
{
    public interface ISportsService
    {
        void Save(Sport sport);
        void Delete(Sport sport);
		IEnumerable<Sport?> GetAll(Expression<Func<Sport, bool>>? filter = null
						  , Func<IQueryable<Sport>, IOrderedQueryable<Sport>>? orderBy = null,
						   string? propertiesName = null);
		bool Exist(Sport sport);
        bool Related(Sport sport);
		Sport? Get(Expression<Func<Sport, bool>>? filter = null,
				   string? propertiesName = null,
				   bool tracked = true);
        int GetQuantity();
    }
}
