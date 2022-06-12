using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Restaurant.Data.Entities.Categories;

namespace Restaurant.Data.Entities.Foods
{
    public interface IFood
    {
        public string Name { get; set; }
        public decimal Price { get; set; }

        public string CategoryId { get; set; }
        public Category Category { get; set; }
    }
}
