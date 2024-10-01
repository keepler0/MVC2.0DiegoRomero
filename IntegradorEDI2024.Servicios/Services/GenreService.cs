using IntegradorEDI2024.Datos;
using IntegradorEDI2024.Datos.Interfaces;
using IntegradorEDI2024.Entidades;
using IntegradorEDI2024.Entidades.Enum;
using IntegradorEDI2024.Servicios.Interfaces;
using System.Linq.Expressions;

namespace IntegradorEDI2024.Servicios.Services
{
    public class GenreService : IGenreService
    {
        private readonly IGenresRepository _repository;
        private IUnitOfWork _unitOfWork;

        public GenreService(IGenresRepository repository, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }

        public void Delete(Genre genre)
        {
            try
            {
                _unitOfWork.BeginTransaction();
                _repository.Delete(genre);
                _unitOfWork.Commit();
            }
            catch (Exception)
            {
                _unitOfWork.Rollback();
                throw;
            }
        }

        public bool Exist(Genre genre)
        {
            try
            {
                return _repository.Exist(genre);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public Genre? Get(Expression<Func<Genre, bool>>? filter = null, string? propertiesName = null, bool tracked = true)
        {
            return _repository.Get(filter, propertiesName, tracked);
        }

        public IEnumerable<Genre?> GetAll(Expression<Func<Genre, bool>>? filter = null, Func<IQueryable<Genre>, IOrderedQueryable<Genre>>? orderBy = null, string? propertiesName = null)
        {
            return _repository.GetAll(filter, orderBy, propertiesName);
        }


        public Genre? GetGenreByName(string GenreName)
        {
            try
            {
                return _repository.GetGenreByName(GenreName);
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

        public bool Related(Genre genre)
        {
            try
            {
                return _repository.Related(genre);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void Save(Genre genre)
        {
            try
            {
                _unitOfWork.BeginTransaction();
                if (genre.GenreId==0)
                {
                    _repository.Add(genre);
                }
                else
                {
                    _repository.Update(genre);
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
