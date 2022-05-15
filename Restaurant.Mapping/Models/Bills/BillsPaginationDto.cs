using Restaurant.Mapping.Models.Common;

namespace Restaurant.Mapping.Models.Bills
{
    public class BillsPaginationDto : PaginationDto
    {
        public bool? IsClosed { get; set; }
        public int TableNumber { get; set; }
    }
}
