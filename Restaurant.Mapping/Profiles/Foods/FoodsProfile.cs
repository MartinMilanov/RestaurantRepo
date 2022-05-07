using AutoMapper;
using Restaurant.Data.Entities.Foods;
using Restaurant.Mapping.Models.Foods;

namespace Restaurant.Mapping.Profiles.Foods
{
    public class FoodsProfile : Profile
    {
        public FoodsProfile()
        {
            CreateMap<FoodCreateDto, Food>()
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

            CreateMap<FoodUpdateDto, Food>()
                .ForMember(
                    dest => dest.Id,
                    opt => opt.MapFrom(src => src.Id)
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
