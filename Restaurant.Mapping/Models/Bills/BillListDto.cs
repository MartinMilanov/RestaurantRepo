namespace Restaurant.Mapping.Models.Bills
{
    public class BillListDto
    {
        public string Id { get; set; }
        public double Total { get; set; }
        public DateTime Closed { get; set; }
        public bool IsClosed { get; set; }
        public int TableNumber { get; set; }
        public string CreatedBy { get; set; }
    }
}
