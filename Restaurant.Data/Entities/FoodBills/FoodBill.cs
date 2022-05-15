using Restaurant.Data.Entities.Bills;
using Restaurant.Data.Entities.Foods;

namespace Restaurant.Data.Entities.FoodBills
{
    public class FoodBill : IFoodBill
    {
        public string FoodId { get; set; }
        public Food Food { get; set; }
        public string BillId { get; set; }
        public Bill Bill { get; set; }
        public int Quantity { get; set; }
    }
}