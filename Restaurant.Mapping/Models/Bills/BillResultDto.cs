using Restaurant.Mapping.Models.Foods;

namespace Restaurant.Mapping.Models.Bills
{
    public class BillResultDto
    {
        public double Total { get; set; }
        public DateTime Closed { get; set; }
        public bool IsClosed { get; set; }
        public string TableId { get; set; }
        public string CreatedById { get; set; }
        public List<FoodBillListDto> FoodsOrdered { get; set; }
    }
}