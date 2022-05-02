using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Restaurant.Data.Entities.FoodBills;

namespace Restaurant.Data.Common.Configurations.FoodBills
{
    public class FoodBillsConfiguration : IEntityTypeConfiguration<FoodBill>
    {
        public void Configure(EntityTypeBuilder<FoodBill> modelBuilder)
        {
            modelBuilder
            .HasKey(bc => new { bc.FoodId, bc.BillId });

            modelBuilder
                .HasOne(bc => bc.Food)
                .WithMany(b => b.Bills)
                .HasForeignKey(bc => bc.FoodId);

            modelBuilder
                .HasOne(bc => bc.Bill)
                .WithMany(b => b.Foods)
                .HasForeignKey(bc => bc.BillId);
        }
    }
}
