using IntegradorEDI2024.Entidades;
using Microsoft.EntityFrameworkCore;

namespace IntegradorEDI2024.Datos
{
    public class MiDbContext : DbContext
    {
        public MiDbContext()
        {
        }
        public MiDbContext(DbContextOptions<MiDbContext> options):base(options) 
        {
        }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Sport> Sports { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Color> Colors { get; set; }
        public DbSet <Shoe> Shoes  { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=.; 
                                          Integrated Security=true;
                                          Initial Catalog=IntegradorEDI2024;
                                          Trusted_Connection=true;
                                          TrustServerCertificate=true;");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var brandList=new List<Brand>()
            {
                new Brand{BrandId=1,BrandName="Topper"},
                new Brand{BrandId=2,BrandName="Etnies"},
                new Brand{BrandId=3,BrandName="Ocn"},
                new Brand{BrandId=4,BrandName="Vicus"},
                new Brand{BrandId=5,BrandName="Nike"}
            };
            modelBuilder.Entity<Brand>().HasData(brandList);

            var genreList = new List<Genre>()
            {
                new Genre{GenreId=1,GenreName="Male" },
                new Genre{GenreId=2,GenreName="Female"}
            };
            modelBuilder.Entity<Genre>().HasData(genreList);

            var colorList = new List<Color>()
            {
                new Color{ColorId=1,ColorName="red"},
                new Color{ColorId=2,ColorName="black"},
                new Color{ColorId=3,ColorName="white"}
            };
            modelBuilder.Entity<Color>().HasData(colorList);

            var sportList = new List<Sport>()
            {
                new Sport{SportId=1,SportName="Running"},
                new Sport{SportId=2,SportName="Trekking"},
                new Sport{SportId=3,SportName="Football"}
            };
            modelBuilder.Entity<Sport>().HasData(sportList);

            var shoeList = new List<Shoe>()
            {
                new Shoe{
                        ShoeId=1,
                        BrandId=1,
                        SportId=1,
                        GenreId=1,
                        ColorId=1,
                        Model="Capitan",
                        Description="Zapatillas running de tela ultra lijero",
                        Price=22999.99m
                        },
                new Shoe{
                        ShoeId=2,
                        BrandId=2,
                        SportId=2,
                        GenreId=2,
                        ColorId=2,
                        Model="Mamooth",
                        Description="Botas de trekking suela reforzada",
                        Price=48999.99m
                        },
                new Shoe{
                        ShoeId=3,
                        BrandId=5,
                        SportId=3,
                        GenreId=1,
                        ColorId=1,
                        Model="Mercurial Vapor",
                        Description="Botines de football ultra liviano",
                        Price=130789.65m
                        }
            };
            modelBuilder.Entity<Shoe>().HasData(shoeList);
        }

    }
}
