using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace IntegradorEDI2024.Web.ViewModels.Sport
{
	public class SportEditVm
	{
		public int SportId { get; set; }
		[Required(ErrorMessage = "{0} is required")]
		[StringLength(30, ErrorMessage = "{0} El texto no debe ser mayor a 30 caracteres", MinimumLength = 1)]
		[DisplayName("SportName")]
		public string? SportName { get; set; }
	}
}
