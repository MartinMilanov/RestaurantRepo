using AutoMapper;
using Restaurant.Data.Entities.Reservations;
using Restaurant.Mapping.Models.Reservations;

namespace Restaurant.Mapping.Profiles.Reservations
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

            CreateMap<ReservationUpdateDto, Reservation>()
                .ForMember(
                    dest => dest.Id,
                    opt => opt.MapFrom(src => src.Id)
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

            CreateMap<Reservation, ReservationResultDto>()
                .ForMember(
                    dest => dest.CreatedByName,
                    opt => opt.MapFrom(src => src.CreatedBy.NormalizedUserName)
                );
        }
    }
}
