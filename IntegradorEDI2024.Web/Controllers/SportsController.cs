using AutoMapper;
using IntegradorEDI2024.Entidades;
using IntegradorEDI2024.Servicios.Interfaces;
using IntegradorEDI2024.Web.ViewModels.Sport;
using Microsoft.AspNetCore.Mvc;

namespace IntegradorEDI2024.Web.Controllers
{
	public class SportsController : Controller
	{
		private readonly ISportsService _service;
		private readonly IMapper _mapper;

		public SportsController(ISportsService service, IMapper mapper)
		{
			_service = service;
			_mapper = mapper;
		}

		public IActionResult Index()
		{
			var list=_service.GetAll(orderBy: s => s.OrderBy(s => s.SportName));
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
            SportEditVm? sportVm;
            if (id is null || id.Value == 0)
            {
                sportVm = new SportEditVm();
            }
            else
            {
                Sport? sport = _service.Get(filter: s => s.SportId == id);
                if (sport == null) return NotFound();
                sportVm = _mapper.Map<SportEditVm>(sport);
            }
            return View(sportVm);
        }
        [HttpPost]
        public IActionResult UpSert(SportEditVm sportVm)
        {
            if (!ModelState.IsValid)
            {
                return View(sportVm);
            }
            if (_service is null || _mapper is null)
            {
                return StatusCode(StatusCodes
                      .Status500InternalServerError,
                     @"Las dependencias 
                       no estan configuradas 
                       correctamente");
            }
            Sport? sport = _mapper.Map<Sport>(sportVm);
            if (_service.Exist(sport))
            {
                ModelState.AddModelError(string.Empty, "Registro existente");
                return View(sportVm);
            }
            _service.Save(sport);
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
            Sport? sport= _service.Get(filter: s => s.SportId == id);
            if (sport is null)
            {
                return NotFound();
            }
            try
            {
                if (_service.Related(sport))
                {
                    return Json(new { success = false, message = "No ha sido posible eliminar el registro ya que otros registros dependen de esta misma" });
                }
                _service.Delete(sport);
                return Json(new { success = true, message = "Registro eliminado!" });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = ex.Message });
            }
        }
    }
}
