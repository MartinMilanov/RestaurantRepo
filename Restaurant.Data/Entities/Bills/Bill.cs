using Restaurant.Data.Entities.Auth;
using Restaurant.Data.Entities.Common;
using Restaurant.Data.Entities.FoodBills;
using Restaurant.Data.Entities.Tables;

namespace Restaurant.Data.Entities.Bills
{
    public class Bill : BaseEntity, IBill
    {
        public double Total { get; set; }
        public DateTime Closed { get; set; }

        public string TableId { get; set; }
        public Table Table { get; set; }
        public string CreatedById {get;set;}
        public ApplicationUser CreatedBy { get; set; }
        public List<FoodBill> Foods { get; set; }
    }
}