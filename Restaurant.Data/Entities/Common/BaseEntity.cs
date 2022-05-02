namespace Restaurant.Data.Entities.Common
{
    public class BaseEntity : IEntity
    {
        public string Id { get; set; }

        public BaseEntity()
        {
            this.Id = Guid.NewGuid().ToString();
        }
    }
}
