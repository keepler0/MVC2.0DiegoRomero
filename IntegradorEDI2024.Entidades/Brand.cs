using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace IntegradorEDI2024.Entidades
{
    [Index(nameof(BrandName),IsUnique =true)]
    public class Brand
    {
        public int BrandId { get; set; }
        [StringLength(50)]
        public string BrandName { get; set; } = null!;
        public ICollection<Shoe> Shoes { get; set; } = new List<Shoe>();
		public string? ImageUrl { get; set; }
	}
}
