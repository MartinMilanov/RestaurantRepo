﻿using AutoMapper;
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
                    opt => opt.MapFrom(src => src.Id)
                )
                .ForMember(
                    dest => dest.Name,
                    opt => opt.MapFrom(src => src.Name)
                )
                .ForMember(
                    dest => dest.Price,
                    opt => opt.MapFrom(src => src.Price)
                )
                .ForMember(
                    dest => dest.CategoryId,
                    opt => opt.MapFrom(src => src.CategoryId)
                );
        }
    }
}
