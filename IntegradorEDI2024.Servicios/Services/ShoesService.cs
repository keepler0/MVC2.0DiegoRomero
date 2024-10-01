using IntegradorEDI2024.Datos;
using IntegradorEDI2024.Datos.Interfaces;
using IntegradorEDI2024.Entidades;
using IntegradorEDI2024.Entidades.Dto;
using IntegradorEDI2024.Entidades.Enum;
using IntegradorEDI2024.Servicios.Interfaces;
using System.Linq.Expressions;

namespace IntegradorEDI2024.Servicios.Services
{
	public class ShoesService : IShoesService
	{
		private readonly IUnitOfWork _unitOfWork;
		private readonly IShoesRepository _repository;

		public ShoesService(IUnitOfWork unitOfWork, IShoesRepository repository)
		{
			_unitOfWork = unitOfWork;
			_repository = repository;
		}

		public void Delete(Shoe shoe)
		{
			try
			{
				_unitOfWork.BeginTransaction();
				_repository.Delete(shoe);
				_unitOfWork.Commit();
			}
			catch (Exception)
			{
				_unitOfWork.Rollback();
				throw;
			}
		}

		public bool Exist(Shoe shoe)
		{
			try
			{
				return _repository.Exist(shoe);
			}
			catch (Exception)
			{

				throw;
			}
		}

		public IEnumerable<Shoe?> GetAll(Expression<Func<Shoe, bool>>? filter = null, Func<IQueryable<Shoe>, IOrderedQueryable<Shoe>>? orderBy = null, string? propertiesName = null)
		{
			return _repository.GetAll(filter, orderBy, propertiesName);
		}

		public List<ShoeListDto> GetPaginatedList(int page, int itemsPerPage, Orden orden, Brand? brand, Color? color, Sport? sport, Genre? genre)
		{
			try
			{
				return _repository.GetPaginatedList(page, itemsPerPage, orden, brand, color, sport, genre);
			}
			catch (Exception)
			{

				throw;
			}
		}

		public int GetQuantity(Brand? brand, Color? color, Sport? sport, Genre? genre)
		{
			try
			{
				return _repository.GetQuantity(brand, color, sport, genre);
			}
			catch (Exception)
			{

				throw;
			}
		}

		public Shoe? Get(Expression<Func<Shoe, bool>>? filter = null, string? propertiesName = null, bool tracked = true)
		{
			return _repository.Get(filter, propertiesName, tracked);
		}

		public void Save(Shoe shoe)
		{
			try
			{
				_unitOfWork.BeginTransaction();
				if (shoe.ShoeId == 0)
				{
					_repository.Add(shoe);
				}
				else
				{
					_repository.Edit(shoe);
				}
				_unitOfWork.Commit();
			}
			catch (Exception)
			{
				_unitOfWork.Rollback();
				throw;
			}
		}
	}
}
