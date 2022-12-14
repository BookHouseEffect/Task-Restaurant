using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Restaurant.DataAccess.Entities;

namespace Restaurant.DataAccess.Maps
{
    public class RestaurantMap : IEntityTypeConfiguration<DbRestaurant>
    {
        public void Configure(EntityTypeBuilder<DbRestaurant> builder)
        {
            builder.ToTable("Restaurant");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id).HasColumnName("Id");
            builder.Property(x => x.RestaurantName).IsRequired().HasMaxLength(100).HasColumnName("RestaurnatName");
            builder.Property(x => x.NumberOfTables).IsRequired().HasColumnName("NumberOfTables");
        }
    }
}
