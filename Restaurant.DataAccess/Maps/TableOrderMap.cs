using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Restaurant.DataAccess.Entities;

namespace Restaurant.DataAccess.Maps
{
    public class TableOrderMap : IEntityTypeConfiguration<TableOrder>
    {
        public void Configure(EntityTypeBuilder<TableOrder> builder)
        {
            builder.ToTable("TableOrder");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id).HasColumnName("Id");
            builder.Property(x => x.RestaurantId).IsRequired().HasColumnName("RestaurantId");
            builder.Property(x => x.TableNumber).IsRequired().HasColumnName("TableNumber");
            builder.Property(x => x.TableOwner).IsRequired().HasColumnName("TableOwner");
            builder.Property(x => x.ClosedOrder).IsRequired().HasColumnName("ClosedOrder");

            builder.HasOne(x => x.RestaurantTable).WithMany().HasForeignKey(x => new { x.RestaurantId, x.TableNumber });
            builder.HasOne(x => x.User).WithMany().HasForeignKey(x => x.TableOwner);
        }
    }
}
