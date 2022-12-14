using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Restaurant.DataAccess.Entities;

namespace Restaurant.DataAccess.Maps
{
    public class UserMap : IEntityTypeConfiguration<DbUser>
    {
        public void Configure(EntityTypeBuilder<DbUser> builder)
        {
            builder.ToTable("User");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id).HasColumnName("Id");
            builder.Property(x => x.DisplayName).IsRequired().HasMaxLength(100).HasColumnName("DisplayName");
            builder.Property(x => x.UserName).IsRequired().HasMaxLength(255).HasColumnName("UserName");
            builder.Property(x => x.WorkingAtRestaurantId).HasColumnName("WorkingAtRestaurantId");

            builder.HasOne(x => x.Restaurant).WithMany().HasForeignKey(x => x.WorkingAtRestaurantId);
        }
    }
}
