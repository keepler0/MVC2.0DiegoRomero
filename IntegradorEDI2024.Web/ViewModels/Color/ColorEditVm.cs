using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace IntegradorEDI2024.Web.ViewModels.Color
{
    public class ColorEditVm
    {
        public int ColorId { get; set; }
        [Required(ErrorMessage = "{0} is required")]
        [StringLength(30, ErrorMessage = "{0} El texto no debe ser mayor a 30 caracteres", MinimumLength = 1)]
        [DisplayName("ColorName")]
        public string? ColorName { get; set; }
    }
}
