﻿using Restaurant.Mapping.Models.Foods;

namespace Restaurant.Mapping.Models.Bills
{
    public class BillResultDto
    {
        public string Id { get; set; }
        public double Total { get; set; }
        public DateTime ClosedDate { get; set; }
        public bool IsClosed { get; set; }
        public int TableNumber { get; set; }
        public List<FoodBillListDto> FoodsOrdered { get; set; }
    }
}