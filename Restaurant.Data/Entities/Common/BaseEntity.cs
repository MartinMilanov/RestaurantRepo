using System.ComponentModel.DataAnnotations.Schema;

namespace Restaurant.Data.Entities.Common
{
    public class BaseEntity : IEntity, IVersionable
    {
        public BaseEntity()
        {
            this.Id = Guid.NewGuid().ToString();
            this.LastEdited = DateTime.Now;
        }

        public string Id { get; set; }

        [Column("LastEdited18118164")]
        public DateTime LastEdited { get; set; }
    }
}
