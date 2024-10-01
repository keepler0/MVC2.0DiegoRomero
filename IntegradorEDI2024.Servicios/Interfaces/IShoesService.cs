using IntegradorEDI2024.Entidades;
using IntegradorEDI2024.Entidades.Dto;
using IntegradorEDI2024.Entidades.Enum;
using System.Linq.Expressions;

namespace IntegradorEDI2024.Servicios.Interfaces
{
    public interface IShoesService
    {
        void Save(Shoe shoe);
        void Delete(Shoe shoe);
		IEnumerable<Shoe?> GetAll(Expression<Func<Shoe, bool>>? filter = null
								  , Func<IQueryable<Shoe>, IOrderedQueryable<Shoe>>? orderBy = null,
								   string? propertiesName = null);
        bool Exist(Shoe shoe);
		Shoe? Get(Expression<Func<Shoe, bool>>? filter = null,
				   string? propertiesName = null,
				   bool tracked = true);
		int GetQuantity(Brand? brand, Color? color, Sport? sport, Genre? genre);
        List<ShoeListDto> GetPaginatedList(int page, int itemsPerPage,Orden orden, Brand? brand, Color? color, Sport? sport, Genre? genre);
    }
}
