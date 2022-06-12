using Restaurant.Data.Entities.Categories;
using Restaurant.Data.Entities.Common;
using Restaurant.Data.Entities.FoodBills;

namespace Restaurant.Data.Entities.Foods
{
    public class Food : BaseEntity, IFood
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string CategoryId { get; set; }
        public Category Category { get; set; }
        public List<FoodBill> Bills { get; set; }
    }
}