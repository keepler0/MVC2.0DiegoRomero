using IntegradorEDI2024.Entidades;
using IntegradorEDI2024.Entidades.Dto;
using IntegradorEDI2024.Entidades.Enum;

namespace IntegradorEDI2024.Datos.Interfaces
{
    public interface IShoesRepository:IGenericRepository<Shoe>
	{
        void Edit(Shoe shoe);//se queda
        bool Exist(Shoe shoe);//se queda
		int GetQuantity(Brand? brand, Color? color, Sport? sport, Genre? genre);//se queda
        List<ShoeListDto> GetPaginatedList(int page, int itemsPerPage,Orden orden, Brand? brand, Color? color, Sport? sport, Genre? genre);
        void SaveChanges();

	}
}
