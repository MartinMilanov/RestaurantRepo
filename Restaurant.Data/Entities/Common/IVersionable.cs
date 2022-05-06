namespace Restaurant.Data.Entities.Common
{
    public interface IVersionable
    {
        public DateTime LastEdited { get; set; }
    }
}
