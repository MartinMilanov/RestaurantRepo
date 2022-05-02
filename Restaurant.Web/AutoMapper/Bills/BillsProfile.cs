using AutoMapper;
using Restaurant.Data.Entities.Bills;
using Restaurant.Web.Models.Request.Bills;

namespace Restaurant.Web.AutoMapper.Bills
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
                    dest => dest.Total,
                    opt => opt.MapFrom(src => src.Total)
                )
                .ForMember(
                    dest => dest.CreatedById,
                    opt => opt.MapFrom(src => src.CreatedById)
                );

            CreateMap<BillUpdateDto, Bill>()
                .ForMember(
                    dest => dest.Id,
                    opt => opt.MapFrom(src => src.Id)
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
                    dest => dest.Total,
                    opt => opt.MapFrom(src => src.Total)
                )
                .ForMember(
                    dest => dest.CreatedById,
                    opt => opt.MapFrom(src => src.CreatedById)
                );
        }
    }
}
