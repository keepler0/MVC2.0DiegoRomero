using System.ComponentModel.DataAnnotations;

namespace IntegradorEDI2024.Entidades
{
    public class Shoe
    {
        public int ShoeId { get; set; }
        public int BrandId { get; set; }
        public Brand? Brand { get; set; }
        public int SportId { get; set; }
        public Sport? Sport { get; set; }
        public int GenreId { get; set; }
        public Genre? Genre { get; set; }
        public int ColorId { get; set; }
        public Color? Color { get; set; }
        [StringLength(150)]
        public string Model { get; set; } = null!;
        public string Description { get; set; } = null!;
        public decimal Price { get; set; }
        public string name => Brand != null ? Brand.BrandName + Model : "N/A" + Model;

        public string? ImageUrl { get; set; }
	}
}
