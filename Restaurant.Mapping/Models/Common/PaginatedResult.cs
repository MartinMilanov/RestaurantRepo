namespace Restaurant.Mapping.Models.Common
{
    public class PaginatedResult<T>
    {
        public int Count { get; set; }
        public IEnumerable<T> Items { get; set; }

        public PaginatedResult(int count, IEnumerable<T> items)
        {
            Count = count;
            Items = items;
        }
    }
}
