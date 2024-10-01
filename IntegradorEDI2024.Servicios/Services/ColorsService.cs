using IntegradorEDI2024.Datos;
using IntegradorEDI2024.Datos.Interfaces;
using IntegradorEDI2024.Entidades;
using IntegradorEDI2024.Entidades.Enum;
using IntegradorEDI2024.Servicios.Interfaces;
using Microsoft.EntityFrameworkCore.Query.Internal;
using System.Linq.Expressions;

namespace IntegradorEDI2024.Servicios.Services
{
    public class ColorsService : IColorsService
    {
        private IUnitOfWork _unitOfWork;
        private readonly IColorsRepository _repository;

        public ColorsService(IUnitOfWork unitOfWork, IColorsRepository colorsRepository)
        {
            _unitOfWork = unitOfWork;
            _repository = colorsRepository;
        }

        public void Delete(Color color)
        {
            try
            {
                _unitOfWork.BeginTransaction();
                _repository.Delete(color);
                _unitOfWork.Commit();

            }
            catch (Exception)
            {
                _unitOfWork.Rollback();
                throw;
            }
        }

        public bool Exist(Color color)
        {
            try
            {
                return _repository.Exist(color);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public Color? Get(Expression<Func<Color, bool>>? filter = null, string? propertiesName = null, bool tracked = true)
        {
            try
            {
                return _repository.Get(filter, propertiesName, tracked);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public IEnumerable<Color?> GetAll(Expression<Func<Color, bool>>? filter = null, Func<IQueryable<Color>, IOrderedQueryable<Color>>? orderBy = null, string? propertiesName = null)
        {
            try
            {
                return _repository.GetAll(filter, orderBy, propertiesName);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool Related(Color color)
        {
            try
            {
                return _repository.Related(color);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void Save(Color color)
        {
            try
            {
                _unitOfWork.BeginTransaction();
                if (color.ColorId==0)
                {
                    _repository.Add(color);
                }
                else
                {
                    _repository.Edit(color);
                }
                _unitOfWork.Commit();
            }
            catch (Exception)
            {
                _unitOfWork.Rollback();
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

        //public List<Color> GetPaginatedList(int page, int itemsPerPage,Orden orden)
        //{
        //    try
        //    {
        //        return _repository.GetPaginatedList(page, itemsPerPage,orden);
        //    }
        //    catch (Exception)
        //    {

        //        throw;
        //    }
        //}
    }
}
