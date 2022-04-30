using AutoMapper;
using Restaurant.Data.Entities.Categories;
using Restaurant.Web.Models.Request.Categories;

namespace Restaurant.Web.AutoMapper.Categories
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
        }
    }
}
