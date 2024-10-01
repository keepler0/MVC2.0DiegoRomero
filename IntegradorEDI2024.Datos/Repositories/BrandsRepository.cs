using IntegradorEDI2024.Datos.Interfaces;
using IntegradorEDI2024.Entidades;

namespace IntegradorEDI2024.Datos.Repositories
{
	public class BrandsRepository : GenericRepository<Brand>, IBrandsRepository
	{
		private readonly MiDbContext _context;
		public BrandsRepository(MiDbContext context) : base(context)
		{
			_context = context;
		}
		public void Edit(Brand brand)
		{
			_context.Brands.Update(brand);
		}

		public bool Exist(Brand brand)
		{
			if (brand.BrandId == 0)
			{
				return _context.Brands.Any(br => br.BrandName == brand.BrandName);
			}
			return _context.Brands.Any(br => br.BrandName == brand.BrandName && br.BrandId != brand.BrandId);
		}
		public Brand? GetBrandByName(string BrandName) => _context.Brands.SingleOrDefault(br => br.BrandName == BrandName);

		//public List<Brand> GetPaginatedList(int page, int itemsPerPage,Orden orden)
		//{
		//    var list=new List<Brand>();
		//    switch (orden) 
		//    {
		//        case Orden.AZ:
		//            list = _context.Brands
		//                         .AsNoTracking()
		//                         .OrderBy(b => b.BrandName)
		//                         .Skip(page * itemsPerPage)
		//                         .Take(itemsPerPage)
		//                         .ToList();
		//            break;
		//        case Orden.ZA:
		//            list = _context.Brands
		//                         .AsNoTracking()
		//                         .OrderByDescending(b => b.BrandName)
		//                         .Skip(page * itemsPerPage)
		//                         .Take(itemsPerPage)
		//                         .ToList();
		//            break;
		//    }
		//    return list;
		//}

		public int GetQuantity()
		{
			return _context.Brands.Count();
		}

		public bool Related(Brand brand) => _context.Shoes.Any(sh => sh.BrandId == brand.BrandId);
		public void SaveChanges()
		{
			_context.SaveChanges();
		}
	}
}
