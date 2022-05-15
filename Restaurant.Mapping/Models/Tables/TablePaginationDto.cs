using Restaurant.Mapping.Models.Common;

namespace Restaurant.Mapping.Models.Tables
{
    public class TablePaginationDto : PaginationDto
    {
        public int TableNumer { get; set; }
        public int Seats { get; set; }
    }
}
