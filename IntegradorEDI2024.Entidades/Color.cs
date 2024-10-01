using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace IntegradorEDI2024.Entidades
{
    [Index(nameof(ColorName),IsUnique =true)]
    public class Color
    {
        public int ColorId { get; set; }
        [StringLength(50)]
        public string ColorName { get; set; } = null!;
        public ICollection<Shoe> Shoes { get; set; } = new List<Shoe>();

    }
}
