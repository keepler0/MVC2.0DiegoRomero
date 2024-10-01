using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace IntegradorEDI2024.Web.ViewModels.Brand
{
	public class BrandEditVm
	{
		public int BrandId { get; set; }
		[Required(ErrorMessage = "{0} is required")]
		[StringLength(30, ErrorMessage = "{0} El texto no debe ser mayor a 30 caracteres", MinimumLength = 1)]
		[DisplayName("BrandName")]
		public string? BrandName { get; set; }
		[Display(Name = "Image")]
		public string? ImageUrl { get; set; }
		public IFormFile? ImageFile { get; set; }
		[Display(Name = "Remove image")]
		public bool RemoveImage { get; set; }
	}
}
