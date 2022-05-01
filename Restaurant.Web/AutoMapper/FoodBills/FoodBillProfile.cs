using AutoMapper;
using Restaurant.Data.Entities.FoodBills;
using Restaurant.Web.Models.Request.Bills;

namespace Restaurant.Web.AutoMapper.FoodBills
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
        }
    }
}
