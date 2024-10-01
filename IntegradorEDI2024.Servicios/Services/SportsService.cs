using IntegradorEDI2024.Datos;
using IntegradorEDI2024.Datos.Interfaces;
using IntegradorEDI2024.Entidades;
using IntegradorEDI2024.Entidades.Enum;
using IntegradorEDI2024.Servicios.Interfaces;
using System.Linq.Expressions;

namespace IntegradorEDI2024.Servicios.Services
{
	public class SportsService : ISportsService
	{
		private readonly IUnitOfWork _unitOfWork;
		private readonly ISportsRepository _repository;

		public SportsService(IUnitOfWork unitOfWork, ISportsRepository repository)
		{
			_unitOfWork = unitOfWork;
			_repository = repository;
		}

		public void Delete(Sport sport)
		{
			try
			{
				_unitOfWork.BeginTransaction();
				_repository.Delete(sport);
				_unitOfWork.Commit();
			}
			catch (Exception)
			{
				_unitOfWork.Rollback();
				throw;
			}
		}

		public bool Exist(Sport sport)
		{
			try
			{
				return _repository.Exist(sport);
			}
			catch (Exception)
			{

				throw;
			}
		}


		public int GetQuantity()
		{
			try
			{
				return _repository.GetQuantity();
			}
			catch (Exception)
			{

				throw;
			}
		}

		public bool Related(Sport sport)
		{
			try
			{
				return _repository.Related(sport);
			}
			catch (Exception)
			{

				throw;
			}
		}

		public void Save(Sport sport)
		{
			try
			{
				_unitOfWork.BeginTransaction();
				if (sport.SportId == 0)
				{
					_repository.Add(sport);
				}
				else
				{
					_repository.Edit(sport);
				}
				_unitOfWork.Commit();
			}
			catch (Exception)
			{
				_unitOfWork.Rollback();
				throw;
			}
		}
		public IEnumerable<Sport?> GetAll(Expression<Func<Sport, bool>>? filter = null, Func<IQueryable<Sport>, IOrderedQueryable<Sport>>? orderBy = null, string? propertiesName = null)
		{
			return _repository.GetAll(filter, orderBy, propertiesName);
		}

		public Sport? Get(Expression<Func<Sport, bool>>? filter = null, string? propertiesName = null, bool tracked = true)
		{
			return _repository.Get(filter, propertiesName, tracked);
		}
	}
}
