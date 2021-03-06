using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Restaurant.Data.Entities.Bills;

namespace Restaurant.Data.Common.Configurations.Bills
{
    public class BillsConfiguration : IEntityTypeConfiguration<Bill>
    {
        public void Configure(EntityTypeBuilder<Bill> builder)
        {
            builder
                .HasOne(x => x.Table)
                .WithMany(x => x.Bills)
                .HasForeignKey(x => x.TableId)
                .IsRequired(false);
        }
    }
}
