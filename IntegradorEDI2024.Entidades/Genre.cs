using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace IntegradorEDI2024.Entidades
{
    [Index(nameof(GenreName), IsUnique = true)]
    public class Genre
    {
        public int GenreId { get; set; }
        [StringLength(10)]
        public string GenreName { get; set; } = null!;
        public ICollection<Shoe> Shoes { get; set; } = new List<Shoe>();
    }
}
