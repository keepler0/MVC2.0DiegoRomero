using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace IntegradorEDI2024.Web.ViewModels.Genre
{
    public class GenreEditVm
    {
        public int GenreId { get; set; }
        [Required(ErrorMessage = "{0} is required")]
        [StringLength(30, ErrorMessage = "{0} El texto no debe ser mayor a 30 caracteres", MinimumLength = 1)]
        [DisplayName("GenreName")]
        public string? GenreName { get; set; }
    }
}
