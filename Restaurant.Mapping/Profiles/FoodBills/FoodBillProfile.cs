using AutoMapper;
using Restaurant.Data.Entities.FoodBills;
using Restaurant.Mapping.Models.Bills;
using Restaurant.Mapping.Models.Foods;

namespace Restaurant.Mapping.Profiles.FoodBills
{
    public class FoodBillProfile : Profile
    {
        public FoodBillProfile()
        {
            CreateMap<FoodBillDto, FoodBill>()
                .ForMember(
                    dest => dest.FoodId,
                    opt => opt.MapFrom(src => src.FoodId)
                )
                .ForMember(
                    dest => dest.BillId,
                    opt => opt.MapFrom(src => src.BillId)
                );

            CreateMap<FoodBill, FoodBillListDto>()
                .ForMember(
                    dest => dest.FoodId,
                    opt => opt.MapFrom(src => src.FoodId)
                )
                .ForMember(
                    dest => dest.Name,
                    opt => opt.MapFrom(src => src.Food.Name)
                );
        }
    }
}
