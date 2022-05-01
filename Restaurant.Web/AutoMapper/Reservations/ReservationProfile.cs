﻿using AutoMapper;
using Restaurant.Data.Entities.Reservations;
using Restaurant.Web.Models.Request.Reservations;

namespace Restaurant.Web.AutoMapper.Reservations
{
    public class ReservationProfile : Profile
    {
        public ReservationProfile()
        {
            CreateMap<ReservationCreateDto, Reservation>()
                .ForMember(
                    dest => dest.Id,
                    opt => Guid.NewGuid().ToString()
                )
                .ForMember(
                    dest => dest.PeopleCount,
                    opt => opt.MapFrom(src => src.PeopleCount)
                )
                .ForMember(
                    dest => dest.ReserveeName,
                    opt => opt.MapFrom(src => src.ReserveeName)
                )
                .ForMember(
                    dest => dest.Date,
                    opt => opt.MapFrom(src => src.Date)
                )
                .ForMember(
                    dest => dest.TableId,
                    opt => opt.MapFrom(src => src.TableId)
                )
                .ForMember(
                    dest => dest.CreatedById,
                    opt => opt.MapFrom(src => src.CreatedById)
                );
        }
    }
}