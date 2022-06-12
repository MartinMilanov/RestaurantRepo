using AutoMapper;
using Restaurant.Data.Entities.Bills;
using Restaurant.Mapping.Models.Bills;

namespace Restaurant.Mapping.Profiles.Bills
{
    public class BillsProfile : Profile
    {
        public BillsProfile()
        {
            CreateMap<BillCreateDto, Bill>()
                .ForMember(
                    dest => dest.Id,
                    opt => Guid.NewGuid().ToString()
                )
                .ForMember(
                    dest => dest.IsClosed,
                    opt => opt.MapFrom(src => src.IsClosed)
                )
                .ForMember(
                    dest => dest.TableId,
                    opt => opt.MapFrom(src => src.TableId)
                )
                .ForMember(
                    dest => dest.CreatedById,
                    opt => opt.MapFrom(src => src.CreatedById)
                );

            CreateMap<BillUpdateDto, Bill>()
                .ForMember(
                    dest => dest.IsClosed,
                    opt => opt.MapFrom(src => src.IsClosed)
                )
                .ForMember(
                    dest => dest.TableId,
                    opt => opt.MapFrom(src => src.TableId)
                )
                .ForMember(
                    dest => dest.Total,
                    opt => opt.MapFrom(src => src.Total)
                )
                .ForMember(
                    dest => dest.CreatedById,
                    opt => opt.MapFrom(src => src.CreatedById)
                );

            CreateMap<Bill, BillListDto>()
                .ForMember(
                    dest => dest.Id,
                    opt => opt.MapFrom(src => src.Id)
                )
                .ForMember(
                    dest => dest.IsClosed,
                    opt => opt.MapFrom(src => src.IsClosed)
                )
                .ForMember(
                    dest => dest.TableNumber,
                    opt => opt.MapFrom(src => src.Table.TableNumber)
                )
                .ForMember(
                    dest => dest.Total,
                    opt => opt.MapFrom(src => src.Total)
                )
                .ForMember(
                    dest => dest.CreatedBy,
                    opt => opt.MapFrom(src => src.CreatedBy.NormalizedUserName)
                );

            CreateMap<Bill, BillResultDto>()
                .ForMember(
                    dest => dest.Id,
                    opt => opt.MapFrom(src => src.Id)
                )
                .ForMember(
                    dest => dest.IsClosed,
                    opt => opt.MapFrom(src => src.IsClosed)
                )
                .ForMember(
                    dest => dest.ClosedDate,
                    opt => opt.MapFrom(src => src.Closed)
                )
                .ForMember(
                    dest => dest.TableNumber,
                    opt => opt.MapFrom(src => src.Table.TableNumber)
                )
                .ForMember(
                    dest => dest.Total,
                    opt => opt.MapFrom(src => src.Total)
                );
        }
    }
}
