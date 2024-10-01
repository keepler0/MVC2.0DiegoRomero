namespace IntegradorEDI2024.Web.ViewModels.Shoes
{
	public class ShoeListVm
	{
		public int ShoeId { get; set; }
		public string? BrandName { get; set; }
		public string Model { get; set; } = null!;
		public decimal Price { get; set; }
		public string Name => $"{BrandName} {Model}";
        //como esta clase es solo para mostrar en lista deberia abstraer algunas props
    }
}
