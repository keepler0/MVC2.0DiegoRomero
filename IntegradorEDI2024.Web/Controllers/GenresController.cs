using AutoMapper;
using IntegradorEDI2024.Entidades;
using IntegradorEDI2024.Servicios.Interfaces;
using IntegradorEDI2024.Web.ViewModels.Genre;
using Microsoft.AspNetCore.Mvc;

namespace IntegradorEDI2024.Web.Controllers
{
    public class GenresController : Controller
    {
        private readonly IGenreService _service;
        private readonly IMapper _mapper;

        public GenresController(IGenreService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        public IActionResult Index()
        {
            var list = _service?.GetAll(orderBy: g => g.OrderBy(g => g.GenreName));
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
            GenreEditVm? genreVm;
            if (id is null || id.Value == 0)
            {
                genreVm = new GenreEditVm();
            }
            else
            {
                Genre? genre = _service.Get(filter: g => g.GenreId == id);
                if (genre == null) return NotFound();
                genreVm = _mapper.Map<GenreEditVm>(genre);
            }
            return View(genreVm);
        }
        [HttpPost]
        public IActionResult UpSert(GenreEditVm genreVm)
        {
            if (!ModelState.IsValid)
            {
                return View(genreVm);
            }
            if (_service is null || _mapper is null)
            {
                return StatusCode(StatusCodes
                      .Status500InternalServerError,
                     @"Las dependencias 
                       no estan configuradas 
                       correctamente");
            }
            Genre? genre= _mapper.Map<Genre>(genreVm);
            if (_service.Exist(genre))
            {
                ModelState.AddModelError(string.Empty, "Registro existente");
                return View(genreVm);
            }
            _service.Save(genre);
            TempData["success"] = "Registro agregado/editado correctamente!";
            return RedirectToAction("Index");
        }
        [HttpDelete]
        [ValidateAntiForgeryToken]
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
            Genre? genre = _service.Get(filter: g => g.GenreId == id);
            if (genre is null)
            {
                return NotFound();
            }
            try
            {
                if (_service.Related(genre))
                {
                    return Json(new { success = false, message = "No ha sido posible eliminar el registro ya que otros registros dependen de esta misma" });
                }
                _service.Delete(genre);
                return Json(new { success = true, message = "Registro eliminado!" });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = ex.Message });
            }
        }
    }
}
