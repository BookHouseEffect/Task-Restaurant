using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Restaurant.DataAccess.Entities;

namespace Restaurant.DataAccess.Maps
{
    public class RestaurantTableMap : IEntityTypeConfiguration<RestaurantTable>
    {
        public void Configure(EntityTypeBuilder<RestaurantTable> builder)
        {
            builder.ToTable("RestaurantTable");

            builder.HasKey(x => new { x.RestaurantId, x.TableNumber });
            builder.Property(x => x.RestaurantId).HasColumnName("RestaurantId");
            builder.Property(x => x.TableNumber).HasColumnName("TableNumber");
            builder.Property(x => x.HasActiveOrder).IsRequired().HasColumnName("HasActiveOrder");

            builder.HasOne(x => x.Restaurant).WithMany().HasForeignKey(x => x.RestaurantId);
        }
    }
}
