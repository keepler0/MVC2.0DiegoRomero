using Microsoft.AspNetCore.Mvc.Rendering;

namespace IntegradorEDI2024.Web.ViewModels.Shoes
{
	public class ShoeFilterVm
	{
		public List<ShoeListVm> ShoesListVm { get; set; } = null!;
        public List<SelectListItem> Brands { get; set; } = null!;
		public List<SelectListItem> Colors { get; set; } = null!;
		public List<SelectListItem> Genres { get; set; } = null!;
		public List<SelectListItem> Sports { get; set; } = null!;

	}
}
