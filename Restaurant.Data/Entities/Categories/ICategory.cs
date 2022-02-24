using Restaurant.Data.Entities.Foods;
using System.Collections.Generic;

namespace Restaurant.Data.Entities.Categories
{
    public interface ICategory
    {
        public string Name { get; set; }
        public List<Food> Foods { get; set; }
    }
}