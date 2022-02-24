using Restaurant.Data.Entities.FoodBills;

namespace Restaurant.Data.Entities.Bills
{
    public interface IBill
    {
        public double Total { get; set; }
        public DateTime Closed { get; set; }
        public List<FoodBill> Foods { get; set; }
    }
}