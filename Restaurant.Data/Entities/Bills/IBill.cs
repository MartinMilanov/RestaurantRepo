using Restaurant.Data.Entities.FoodBills;
using Restaurant.Data.Entities.Tables;

namespace Restaurant.Data.Entities.Bills
{
    public interface IBill
    {
        public decimal Total { get; set; }
        public DateTime Closed { get; set; }
        public string TableId { get; set; }
        public Table Table { get; set; }
        public List<FoodBill> Foods { get; set; }
    }
}