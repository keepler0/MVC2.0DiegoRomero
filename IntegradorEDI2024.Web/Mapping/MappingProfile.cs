using AutoMapper;
using IntegradorEDI2024.Entidades;
using IntegradorEDI2024.Web.ViewModels.Brand;
using IntegradorEDI2024.Web.ViewModels.Color;
using IntegradorEDI2024.Web.ViewModels.Genre;
using IntegradorEDI2024.Web.ViewModels.Shoes;
using IntegradorEDI2024.Web.ViewModels.Sport;

namespace IntegradorEDI2024.Web.Mapping
{
	public class MappingProfile:Profile
	{
        public MappingProfile()
        {
            LoadBrandsMapping();
			LoadColorsMapping();
			LoadSportMapping();
            LoadGenresMapping();
            LoadShoesMapping();
        }

        private void LoadShoesMapping()
        {
            CreateMap<Shoe, ShoeListVm>()
            .ForMember(dest => dest.BrandName, opt => opt.MapFrom(src => src.Brand!.BrandName));
			CreateMap<Shoe, ShoeDetailVm>().ForMember(dest => dest.BrandName, opt => opt.MapFrom(src => src.Brand!.BrandName))
										   .ForMember(dest => dest.GenreName, opt => opt.MapFrom(src => src.Genre!.GenreName))
										   .ForMember(dest => dest.SportName, opt => opt.MapFrom(src => src.Sport!.SportName))
										   .ForMember(dest => dest.ColorName, opt => opt.MapFrom(src => src.Color!.ColorName));
			CreateMap<Shoe, ShoeEditVm>().ReverseMap();
		}

        private void LoadGenresMapping()
        {
            CreateMap<Genre, GenreEditVm>().ReverseMap();
        }

        private void LoadSportMapping()
		{
			CreateMap<Sport,SportEditVm>().ReverseMap();
		}
		private void LoadBrandsMapping()
		{
			CreateMap<Brand,BrandEditVm>().ReverseMap();
		}
		private void LoadColorsMapping()
		{
            CreateMap<Color,ColorEditVm>().ReverseMap();
        }
	}
}
