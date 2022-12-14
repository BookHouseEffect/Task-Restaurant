using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Restaurant.DataAccess.Entities;

namespace Restaurant.DataAccess.Maps
{
    public class TableOrderItemMap : IEntityTypeConfiguration<TableOrderItem>
    {
        public void Configure(EntityTypeBuilder<TableOrderItem> builder)
        {
            builder.ToTable("TableOrderItem");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id).HasColumnName("Id");
            builder.Property(x => x.TableOrderId).IsRequired().HasColumnName("TableOrderId");
            builder.Property(x => x.ProductId).IsRequired().HasColumnName("ProductId");
            builder.Property(x => x.ProductPrice).IsRequired().HasColumnName("ProductPrice");
            builder.Property(x => x.ProductQuantity).IsRequired().HasColumnName("ProductQuantity");
            builder.Property(x => x.ItemSum).IsRequired().HasColumnName("ItemSum");

            builder.HasOne(x => x.TableOrder).WithMany().HasForeignKey(x => x.TableOrderId);
            builder.HasOne(x => x.Product).WithMany().HasForeignKey(x => x.ProductId);
        }
    }
}
