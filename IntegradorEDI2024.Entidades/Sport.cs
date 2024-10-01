using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace IntegradorEDI2024.Entidades
{
    [Index(nameof(SportName), IsUnique = true)]
    public class Sport
    {
        public int SportId { get; set; }
        [StringLength(20)]
        public string SportName { get; set; } = null!;
        public ICollection<Shoe> Shoes { get; set; } = new List<Shoe>();
    }
}
