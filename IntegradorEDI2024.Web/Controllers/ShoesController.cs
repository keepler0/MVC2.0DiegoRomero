using AutoMapper;
using IntegradorEDI2024.Entidades;
using IntegradorEDI2024.Servicios.Interfaces;
using IntegradorEDI2024.Web.ViewModels.Shoes;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
//using System.Web.Mvc;

namespace IntegradorEDI2024.Web.Controllers
{
	public class ShoesController : Controller
	{
		private readonly IShoesService? _service;
		private readonly IMapper? _mapper;
		private readonly IBrandsService _brandsService;
		private readonly IColorsService _colorsService;
		private readonly IGenreService? _genreService;
		private readonly ISportsService? _sportsService;
		private readonly IWebHostEnvironment _webHostEnvironment;

		public ShoesController(IShoesService? service,
							   IMapper? mapper,
							   IBrandsService brandsService,
							   IColorsService colorsService,
							   IGenreService? genreService,
							   ISportsService? sportsService,
							   IWebHostEnvironment webHostEnvironment)
		{
			_service = service ?? throw new ArgumentException("Error en las dependencias!"); ;
			_mapper = mapper ?? throw new ArgumentException("Error en las dependencias!"); ;
			_brandsService = brandsService;
			_colorsService = colorsService;
			_genreService = genreService;
			_sportsService = sportsService;
			_webHostEnvironment = webHostEnvironment;
		}

		//public ShoesController(IShoesService? service, IMapper? mapper)
		//{
		//	_service = service??throw new ArgumentException("Error en las dependencias!");
		//	_mapper = mapper ?? throw new ArgumentException("Error en las dependencias!");
		//}

		public IActionResult Index(string? searchTerm=null,bool viewAll=false,
								   int?FilterBrandId=null, int? FilterColorId = null, 
								   int? FilterGenreId = null, int?FilterSportId = null,
								   string orderBy="Brand")
		{
			IEnumerable<Shoe?> listShoes=null;
			ViewBag.currentOrderBy = orderBy;
			if (!viewAll)
			{
				if (!string.IsNullOrEmpty(searchTerm))
				{
					listShoes = _service!.GetAll(propertiesName: "Brand,Sport,Color,Genre",
												 orderBy: s => s.OrderBy(s => s.Brand!.BrandName)
																.ThenBy(s => s.Model),
												 filter: s => s.Brand!.BrandName.Contains(searchTerm) ||
															 s.Color!.ColorName.Contains(searchTerm) ||
															 s.Genre!.GenreName.Contains(searchTerm) ||
															 s.Sport!.SportName.Contains(searchTerm));
					ViewBag.currentSearchTerm = searchTerm;
				}
				else if(FilterBrandId!=null||FilterColorId!=null||FilterGenreId!=null||FilterSportId!=null)
				{
					listShoes = _service!.GetAll(propertiesName: "Brand,Sport,Color,Genre",
																		orderBy: s => s.OrderBy(s => s.Brand!.BrandName)
																		.ThenBy(s => s.Model),
																		filter: s => s.BrandId == FilterBrandId
																			   || s.ColorId == FilterColorId
																			   || s.SportId == FilterSportId
																			   || s.GenreId == FilterGenreId);
					//perdon ausencia del DRY jajajajaja
					ViewBag.currentFilterBrandId = FilterBrandId;
					ViewBag.currentFilterColorId = FilterColorId;
					ViewBag.currentFilterGenreId = FilterGenreId;
					ViewBag.currentFilterSportId = FilterSportId;
				}
				else
				{
					listShoes = _service!.GetAll(propertiesName: "Brand,Sport,Color,Genre",
												 orderBy: s => s.OrderBy(s => s.Brand!.BrandName)
																.ThenBy(s => s.Model));
				}
			}
			else
			{
				listShoes = _service!.GetAll(propertiesName: "Brand,Sport,Color,Genre", 
											 orderBy: s => s.OrderBy(s => s.Brand!.BrandName)
															.ThenBy(s=>s.Model));

			}
			var shoeVmList = _mapper!.Map<List<ShoeListVm>>(listShoes);
			shoeVmList = GetSortList(shoeVmList,orderBy);
			var shoeFilterVm = new ShoeFilterVm
			{
				ShoesListVm = shoeVmList,
				Brands = GetItemsList("Brands"),
				Colors = GetItemsList("Colors"),
				Genres = GetItemsList("Genres"),
				Sports = GetItemsList("Sports")
			};
			return View(shoeFilterVm);
		}

        private List<ShoeListVm> GetSortList(List<ShoeListVm>list, string orderBy)
        {
			switch (orderBy)
			{
				case "Brand":
					return list.OrderBy(s => s.BrandName).ToList();
				case "Model":
					return list.OrderBy(s => s.Model).ToList();
				case "LowToHigh":
					return list.OrderBy(s => s.Price).ToList();
				default:
					return list.OrderByDescending(s => s.Price).ToList();
			}
		}

        public IActionResult UpSert(int? id)
		{
			ShoeEditVm? shoeVm;
			if (id is null || id.Value == 0)
			{
				shoeVm = new ShoeEditVm();
				shoeVm.Brands = GetItemsList("Brands");
				shoeVm.Colors = GetItemsList("Colors");
				shoeVm.Genres = GetItemsList("Genres");
				shoeVm.Sports = GetItemsList("Sports");
			}
			else
			{
				Shoe? shoe = _service!.Get(filter: s => s.ShoeId == id);
				if (shoe == null) return NotFound();
				shoeVm = _mapper!.Map<ShoeEditVm>(shoe);
				shoeVm.Brands = GetItemsList("Brands");
				shoeVm.Colors = GetItemsList("Colors");
				shoeVm.Genres = GetItemsList("Genres");
				shoeVm.Sports = GetItemsList("Sports");
			}
			return View(shoeVm);
		}
		[HttpPost]
		[ValidateAntiForgeryToken]
		public IActionResult UpSert(ShoeEditVm shoeVm)
		{
			if (!ModelState.IsValid)
			{
				shoeVm.Brands = GetItemsList("Brands");
				shoeVm.Colors = GetItemsList("Colors");
				shoeVm.Genres = GetItemsList("Genres");
				shoeVm.Sports = GetItemsList("Sports");
				return View(shoeVm);
			}
			if (_service is null || _mapper is null)
			{
				return StatusCode(StatusCodes
					  .Status500InternalServerError,
					 @"Las dependencias 
                       no estan configuradas 
                       correctamente");
			}
			Shoe? shoe = _mapper.Map<Shoe>(shoeVm);
			if (_service.Exist(shoe))
			{
				ModelState.AddModelError(string.Empty, "Registro existente");
				shoeVm.Brands = GetItemsList("Brands");
				shoeVm.Colors = GetItemsList("Colors");
				shoeVm.Genres = GetItemsList("Genres");
				shoeVm.Sports = GetItemsList("Sports");
				return View(shoeVm);
			}

			string? wwwWebRoot = _webHostEnvironment.WebRootPath;
			if (!shoeVm.RemoveImage)
			{
				if (shoeVm.ImageFile != null)
				{
					var validExtensions = new string[]
					{
						".jpg",
						".png",
						".jpeg"
					};
					string fileExtension = Path.GetExtension(shoeVm.ImageFile.FileName);
					if (!validExtensions.Contains(fileExtension))
					{
						ModelState.AddModelError(string.Empty, "File not allowed!");
						shoeVm.Brands = GetItemsList("Brands");
						shoeVm.Colors = GetItemsList("Colors");
						shoeVm.Genres = GetItemsList("Genres");
						shoeVm.Sports = GetItemsList("Sports");
						return View(shoeVm);
					}
					if (shoeVm.ImageUrl != null)
					{
						string oldFilePath = Path.Combine(wwwWebRoot, shoeVm.ImageUrl.TrimStart('/'));
						if (System.IO.File.Exists(oldFilePath))
						{
							System.IO.File.Delete(oldFilePath);
						}
					}
					string fileName = $"{Guid.NewGuid()}{Path.GetExtension(shoeVm.ImageFile.FileName)}";
					string pathName = Path.Combine(wwwWebRoot, "images/Shoes", fileName);
					using (var fileStream = new FileStream(pathName, FileMode.Create))
					{
						shoeVm.ImageFile.CopyTo(fileStream);
					}
					shoe.ImageUrl = $"/images/Shoes/{fileName}";
				}
				
			}
			else
			{
				string oldFilePath = Path.Combine(wwwWebRoot, shoeVm.ImageUrl.TrimStart('/'));
				if (System.IO.File.Exists(oldFilePath))
				{
					System.IO.File.Delete(oldFilePath);
				}
				shoe.ImageUrl = null;
			}
			
			_service.Save(shoe);
			TempData["success"] = "Registro agregado/editado correctamente!";
			return RedirectToAction("Index");
		}

		public IActionResult Details(int? id)
		{
			if (id is null || id == 0) return NotFound();
			Shoe? shoe = _service!.Get(filter: s => s.ShoeId == id, propertiesName: "Brand,Sport,Color,Genre");
			
			ShoeDetailVm shoeVm = _mapper!.Map<ShoeDetailVm>(shoe);//modificar el autoMapper

			return View(shoeVm);//Aun fata agregar la vista
		}
		[HttpDelete]
		public IActionResult Delete(int? id)
		{
			if (id is null || id.Value == 0)
			{
				return NotFound();
			}
			if (_service is null || _mapper is null)
			{
				return StatusCode(StatusCodes
					.Status500InternalServerError,
					"Dependencias no están configuradas correctamente");
			}
			Shoe? shoe = _service.Get(filter: s => s.ShoeId == id);
			if (shoe is null)
			{
				return NotFound();
			}
			try
			{
				//if (_service.Related(shoe))
				//{
				//	return Json(new { success = false, message = "No ha sido posible eliminar el registro ya que otros registros dependen de esta misma" });
				//}
				_service.Delete(shoe);
				string? wwwWebRoot = _webHostEnvironment.WebRootPath;
				string oldFilePath = Path.Combine(wwwWebRoot, shoe.ImageUrl.TrimStart('/'));
				if (System.IO.File.Exists(oldFilePath))
				{
					System.IO.File.Delete(oldFilePath);
				}
				return Json(new { success = true, message = "Registro eliminado!" });
			}
			catch (Exception ex)
			{
				return Json(new { success = false, message = ex.Message });
			}
		}
		private List<SelectListItem> GetItemsList(string obj)
		{
			List<SelectListItem>? list = null;

			switch (obj)
			{
				case "Brands":
					list=_brandsService!.GetAll(orderBy: o => o.OrderBy(b => b.BrandName))!.Select(b => new SelectListItem
							{
								Value = b!.BrandId.ToString(),
								Text = b.BrandName
							}).ToList();
					break;
				case "Sports":
					list=_sportsService!.GetAll(orderBy: o => o.OrderBy(sp => sp.SportName)).Select(sp => new SelectListItem
							{
								Value = sp!.SportId.ToString(),
								Text = sp.SportName
							}).ToList();
					break;
				case "Genres":
					list=_genreService!.GetAll(orderBy: o => o.OrderBy(g => g.GenreName))!.Select(g => new SelectListItem
					{
						Value = g!.GenreId.ToString(),
						Text = g.GenreName
					}).ToList();
					break;
				case "Colors":
					list= _colorsService!.GetAll(orderBy: o => o.OrderBy(c => c.ColorName))!.Select(c => new SelectListItem
							{
								Value = c!.ColorId.ToString(),
								Text = c.ColorName
							}).ToList();
					break;
			}
			return list!;
		}
	}
	
}
