using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Restaurant.Data.Entities.Reservations;

namespace Restaurant.Data.Common.Configurations.Reservations
{
    public class ReservationsConfiguration : IEntityTypeConfiguration<Reservation>
    {
        public void Configure(EntityTypeBuilder<Reservation> builder)
        {
            builder
                .HasOne(x => x.Table)
                .WithMany(x => x.Reservations)
                .HasForeignKey(x => x.TableId);
        }
    }
}
