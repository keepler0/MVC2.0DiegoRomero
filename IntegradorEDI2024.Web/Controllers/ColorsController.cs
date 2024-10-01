using AutoMapper;
using IntegradorEDI2024.Entidades;
using IntegradorEDI2024.Servicios.Interfaces;
using IntegradorEDI2024.Web.ViewModels.Color;
using Microsoft.AspNetCore.Mvc;

namespace IntegradorEDI2024.Web.Controllers
{
    public class ColorsController : Controller
    {
        private readonly IColorsService _service;
        private readonly IMapper _mapper;

        public ColorsController(IColorsService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        public IActionResult Index()
        {
            var list = _service.GetAll(orderBy:c=>c.OrderBy(c=>c.ColorName));
            return View(list);
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
            ColorEditVm? colorVm;
            if (id is null || id.Value == 0)
            {
                colorVm = new ColorEditVm();
            }
            else
            {
                Color? color = _service.Get(filter: c => c.ColorId == id);
                if (color == null) return NotFound();
                colorVm = _mapper.Map<ColorEditVm>(color);
            }
            return View(colorVm);
        }
        [HttpPost]
        public IActionResult UpSert(ColorEditVm? colorVm)
        {
            if (!ModelState.IsValid)
            {
                return View(colorVm);
            }
            if (_service is null || _mapper is null)
            {
                return StatusCode(StatusCodes
                      .Status500InternalServerError,
                     @"Las dependencias 
                       no estan configuradas 
                       correctamente");
            }
            Color? color = _mapper.Map<Color>(colorVm);
            if (_service.Exist(color))
            {
                ModelState.AddModelError(string.Empty, "Registro existente");
                return View(colorVm);
            }
            _service.Save(color);
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
            Color? color = _service.Get(filter: c => c.ColorId == id);
            if (color is null)return NotFound();

            try
            {
                if (_service.Related(color))
                {
                    return Json(new { success = false, message = "No ha sido posible eliminar el registro ya que otros registros dependen de esta misma" });
                }
                _service.Delete(color);
                return Json(new { success = true, message = "Registro eliminado!" });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = ex.Message });
            }
        }
    }
}
