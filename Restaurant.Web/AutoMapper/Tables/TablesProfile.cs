using AutoMapper;
using Restaurant.Data.Entities.Tables;
using Restaurant.Web.Models.Request.Tables;

namespace Restaurant.Web.AutoMapper.Tables
{
    public class TablesProfile : Profile
    {
        public TablesProfile()
        {
            CreateMap<TableCreateDto, Table>()
                .ForMember(
                    dest => dest.Id,
                    opt => Guid.NewGuid().ToString()
                )
                .ForMember(
                    dest => dest.Seats,
                    opt => opt.MapFrom(src => src.Seats)
                )
                .ForMember(
                    dest => dest.TableNumber,
                    opt => opt.MapFrom(src => src.TableNumber)
                );

            CreateMap<TableUpdateDto, Table>()
                .ForMember(
                    dest => dest.Id,
                    opt => opt.MapFrom(src => src.Id)
                )
                .ForMember(
                    dest => dest.Seats,
                    opt => opt.MapFrom(src => src.Seats)
                )
                .ForMember(
                    dest => dest.TableNumber,
                    opt => opt.MapFrom(src => src.TableNumber)
                );
        }
    }
}
