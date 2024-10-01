using IntegradorEDI2024.Datos;
using IntegradorEDI2024.Datos.Interfaces;
using IntegradorEDI2024.Datos.Repositories;
using IntegradorEDI2024.Servicios.Interfaces;
using IntegradorEDI2024.Servicios.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace IntegradorEDI2024.Ioc
{
    public static class DI
    {
        public static void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<IBrandsService, BrandsService>();
            services.AddScoped<IBrandsRepository, BrandsRepository>();

            services.AddScoped<IGenreService, GenreService>();
            services.AddScoped<IGenresRepository, GenresRepository>();

            services.AddScoped<IColorsService, ColorsService>();
            services.AddScoped<IColorsRepository, ColorsRepository>();

            services.AddScoped<ISportsService, SportsService>();
            services.AddScoped<ISportsRepository, SportsRepository>();

            services.AddScoped<IShoesService, ShoesService>();
            services.AddScoped<IShoesRepository, ShoesRepository>();

            services.AddScoped<IUnitOfWork, UnitOfWork>();

            services.AddDbContext<MiDbContext>(options =>
            {
                options.UseSqlServer(@"Data Source=.; 
                                       Integrated Security=true;
                                       Initial Catalog=IntegradorEDI2024;
                                       Trusted_Connection=true;
                                       TrustServerCertificate=true;");
            });
        }
    }
}
