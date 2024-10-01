using IntegradorEDI2024.Datos.Interfaces;
using IntegradorEDI2024.Entidades;
using IntegradorEDI2024.Entidades.Enum;
using Microsoft.EntityFrameworkCore;

namespace IntegradorEDI2024.Datos.Repositories
{
    public class ColorsRepository : GenericRepository<Color>,IColorsRepository
    {
        private readonly MiDbContext _context;

        public ColorsRepository(MiDbContext context):base(context)
        {
            _context = context;
        }

        public void Edit(Color color)
        {
            _context.Colors.Update(color);
        }

        public bool Exist(Color color)
        {
            if (color.ColorId==0)
            {
                return _context.Colors.Any(c => c.ColorName == color.ColorName);
            }
            return _context.Colors.Any(c=>c.ColorName == color.ColorName && c.ColorId!=color.ColorId);
        }

        //public List<Color> GetPaginatedList(int page, int itemsPerPage,Orden orden)
        //{
        //    var list= new List<Color>();
        //    switch (orden)
        //    {
        //        case Orden.AZ:
        //            list = _context.Colors
        //                           .AsNoTracking()
        //                           .OrderBy(c => c.ColorName)
        //                           .Skip(page * itemsPerPage)
        //                           .Take(itemsPerPage)
        //                           .ToList();
        //            break;
        //        case Orden.ZA:
        //            list = _context.Colors
        //                           .AsNoTracking()
        //                           .OrderByDescending(c => c.ColorName)
        //                           .Skip(page * itemsPerPage)
        //                           .Take(itemsPerPage)
        //                           .ToList();
        //            break;
        //    }
        //    return list;
        //}

        public int GetQuantity()
        {
            return _context.Colors.Count();
        }

        public bool Related(Color color)
        {
            return _context.Shoes.Any(sh => sh.ColorId == color.ColorId);
        }
        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}
