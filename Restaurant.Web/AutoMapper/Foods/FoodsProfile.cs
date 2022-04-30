using AutoMapper;
using Restaurant.Data.Entities.Foods;
using Restaurant.Web.Models.Request.Foods;

namespace Restaurant.Web.AutoMapper.Foods
{
    public class FoodsProfile : Profile
    {
        public FoodsProfile()
        {
            CreateMap<FoodDto, Food>()
                .ForMember(
                    dest => dest.Id,
                    opt => Guid.NewGuid().ToString()
                )
                .ForMember(
                    dest => dest.Name,
                    opt => opt.MapFrom(src => src.Name)
                )
                .ForMember(
                    dest => dest.Price,
                    opt => opt.MapFrom(src => src.Price)
                );
        }
    }
}
