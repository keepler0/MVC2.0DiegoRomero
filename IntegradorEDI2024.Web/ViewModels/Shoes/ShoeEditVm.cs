using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;



namespace IntegradorEDI2024.Web.ViewModels.Shoes
{
	public class ShoeEditVm
	{
		public int ShoeId { get; set; }
        [Required(ErrorMessage = "{0} is required")]
        [Range(1, int.MaxValue, ErrorMessage = "Valor fuera del rango")]
        [DisplayName("Brand")]
        public int BrandId { get; set; }

		[Required(ErrorMessage = "{0} is required")]
		[Range(1, int.MaxValue, ErrorMessage = "Valor fuera del rango")]
		[DisplayName("Color")]
		public int ColorId { get; set; }

		[Required(ErrorMessage = "{0} is required")]
		[Range(1, int.MaxValue, ErrorMessage = "Valor fuera del rango")]
		[DisplayName("Genre")]
		public int GenreId { get; set; }

		[Required(ErrorMessage = "{0} is required")]
		[Range(1, int.MaxValue, ErrorMessage = "Valor fuera del rango")]
		[DisplayName("Sport")]
		public int SportId { get; set; }

		[Required(ErrorMessage = "{0} is required")]
        [StringLength(30, ErrorMessage = "{0} El texto no debe ser mayor a 30 caracteres", MinimumLength = 1)]
        [DisplayName("Model")]
        public string Model { get; set; } = null!;
        public string? Description { get; set; }

		[Required(ErrorMessage = "{0} is required")]
		[Range(1,9999999.99, ErrorMessage = "Valor fuera del rango")]
		[DisplayName("Price")]
		public decimal Price { get; set; }

        [Display(Name = "Image")]
        public string? ImageUrl { get; set; }
        public IFormFile? ImageFile { get; set; }
		[Display(Name ="Remove image")]
		public bool RemoveImage { get; set; }

        [ValidateNever]
		public List<SelectListItem> Brands { get; set; } = null!;
		[ValidateNever]
		public List<SelectListItem> Colors { get; set; } = null!;
		[ValidateNever]
		public List<SelectListItem> Genres { get; set; } = null!;
		[ValidateNever]
		public List<SelectListItem> Sports { get; set; } = null!;
	}
}
