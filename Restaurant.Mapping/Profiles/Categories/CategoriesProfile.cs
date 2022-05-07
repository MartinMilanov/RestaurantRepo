using AutoMapper;
using Restaurant.Data.Entities.Categories;
using Restaurant.Mapping.Models.Categories;

namespace Restaurant.Mapping.Profiles.Categories
{
    public class CategoriesProfile : Profile
    {
        public CategoriesProfile()
        {
            CreateMap<CategoryCreateDto, Category>()
                .ForMember(
                    dest => dest.Id,
                    opt => Guid.NewGuid().ToString()
                )
                .ForMember(
                    dest => dest.Name,
                    opt => opt.MapFrom(src => src.Name)
                );

            CreateMap<CategoryUpdateDto, Category>()
                .ForMember(
                    dest => dest.Id,
                    opt => opt.MapFrom(src => src.Id)
                )
                .ForMember(
                    dest => dest.Name,
                    opt => opt.MapFrom(src => src.Name)
                );
        }
    }
}
