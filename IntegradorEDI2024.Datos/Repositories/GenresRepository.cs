using IntegradorEDI2024.Datos.Interfaces;
using IntegradorEDI2024.Entidades;
using IntegradorEDI2024.Entidades.Enum;
using Microsoft.EntityFrameworkCore;

namespace IntegradorEDI2024.Datos.Repositories
{
    public class GenresRepository :GenericRepository<Genre> ,IGenresRepository
    {
        private readonly MiDbContext _context;

        public GenresRepository(MiDbContext context):base(context)
        {
            _context = context;
        }

        public bool Exist(Genre genre)
        {
            if (genre.GenreId==0)
            {
                return _context.Genres.Any(g => g.GenreName == genre.GenreName);
            }
            return _context.Genres.Any(g => g.GenreName == genre.GenreName && g.GenreId!=genre.GenreId);

        }

        public Genre? GetGenreByName(string GenreName)
        {
            return _context.Genres.FirstOrDefault(g => g.GenreName == GenreName);
        }

        //public List<Genre> GetPaginatedList(int page, int itemsPerPage,Orden orden)
        //{
        //    var list= new List<Genre>();
        //    switch (orden)
        //    {
        //        case Orden.AZ:
        //            list = _context.Genres
        //                           .AsNoTracking()
        //                           .OrderBy(g => g.GenreName)
        //                           .Skip(page * itemsPerPage)
        //                           .Take(itemsPerPage)
        //                           .ToList();
        //            break;
        //        case Orden.ZA:
        //            list = _context.Genres
        //                           .AsNoTracking()
        //                           .OrderByDescending(g => g.GenreName)
        //                           .Skip(page * itemsPerPage)
        //                           .Take(itemsPerPage)
        //                           .ToList();
        //            break;
        //    }
        //    return list;
        //}

        public int GetQuantity()
        {
            return _context.Genres.Count();
        }

        public bool Related(Genre genre)
        {
            return _context.Shoes.Any(sh => sh.GenreId == genre.GenreId);
        }

        public void Update(Genre genre)
        {
            _context.Genres.Update(genre);
        }
        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}
