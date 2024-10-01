using AutoMapper;
using IntegradorEDI2024.Entidades;
using IntegradorEDI2024.Servicios.Interfaces;
using IntegradorEDI2024.Web.ViewModels.Brand;
using Microsoft.AspNetCore.Mvc;

namespace IntegradorEDI2024.Web.Controllers
{
    public class BrandsController : Controller
    {
        private readonly IBrandsService _service;
        private readonly IMapper _mapper;
		private readonly IWebHostEnvironment _webHostEnvironment;


		public BrandsController(IBrandsService service,IMapper mapper, IWebHostEnvironment webHostEnvironment)
        {
            _service = service;
            _mapper = mapper;
            _webHostEnvironment = webHostEnvironment;
        }

        public IActionResult Index()
        {
            var lista = _service?.GetAll(orderBy:b=>b.OrderBy(b=>b.BrandName));
            return View(lista);
        }
        public IActionResult UpSert(int? id)
        {
            if (_service is null || _mapper is null)
			{
				return StatusCode(StatusCodes
					  .Status500InternalServerError,
					 @"Las dependencias 
                       no estan configuradas 
                       correctamente");
			}
            BrandEditVm? brandVm;
			if (id is null || id.Value == 0)
            {
                brandVm=new BrandEditVm();
            }
            else
            {
                Brand? brand = _service.Get(filter: b => b.BrandId == id);
                //TODO:Ultimo punto echo video Clase 10 EDI 27-08 53:16
			    if (brand == null) return NotFound();
                brandVm = _mapper.Map<BrandEditVm>(brand);
            }
			return View(brandVm);
        }
        [HttpPost]
        public IActionResult UpSert(BrandEditVm brandVm) 
        {
            if (!ModelState.IsValid)
            {
                return View(brandVm);
            }
			if (_service is null || _mapper is null)
			{
				return StatusCode(StatusCodes
					  .Status500InternalServerError,
					 @"Las dependencias 
                       no estan configuradas 
                       correctamente");
			}
            Brand? brand=_mapper.Map<Brand>(brandVm);
			if (_service.Exist(brand))
            {
                ModelState.AddModelError(string.Empty, "Registro existente");
                return View(brandVm);
            }
			string? wwwWebRoot = _webHostEnvironment.WebRootPath;
			if (!brandVm.RemoveImage)
			{
				if (brandVm.ImageFile != null)
				{
					var validExtensions = new string[]
					{
						".jpg",
						".png",
						".jpeg"
					};
					string fileExtension = Path.GetExtension(brandVm.ImageFile.FileName);
					if (!validExtensions.Contains(fileExtension))
					{
						ModelState.AddModelError(string.Empty, "File not allowed!");
						return View(brandVm);
					}
					if (brandVm.ImageUrl != null)
					{
						string oldFilePath = Path.Combine(wwwWebRoot, brandVm.ImageUrl.TrimStart('/'));
						if (System.IO.File.Exists(oldFilePath))
						{
							System.IO.File.Delete(oldFilePath);
						}
					}
					string fileName = $"{Guid.NewGuid()}{Path.GetExtension(brandVm.ImageFile.FileName)}";
					string pathName = Path.Combine(wwwWebRoot, "images/Brands", fileName);
					using (var fileStream = new FileStream(pathName, FileMode.Create))
					{
						brandVm.ImageFile.CopyTo(fileStream);
					}
					brand.ImageUrl = $"/images/Brands/{fileName}";
				}

			}
			else
			{
				string oldFilePath = Path.Combine(wwwWebRoot, brandVm.ImageUrl.TrimStart('/'));
				if (System.IO.File.Exists(oldFilePath))
				{
					System.IO.File.Delete(oldFilePath);
				}
				brand.ImageUrl = null;
			}
			_service.Save(brand);
            TempData["success"] = "Registro agregado/editado correctamente!";
            return RedirectToAction("Index");
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
			Brand? brand = _service.Get(filter:b=>b.BrandId==id);
			if (brand is null)
			{
				return NotFound();
			}
            try
            {
                if (_service.Related(brand))
                {
                    return Json(new { success = false, message = "No ha sido posible eliminar el registro ya que otros registros dependen de esta misma" });
                }
                _service.Delete(brand);
				string? wwwWebRoot = _webHostEnvironment.WebRootPath;
				string oldFilePath = Path.Combine(wwwWebRoot, brand.ImageUrl.TrimStart('/'));
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
    }
}
