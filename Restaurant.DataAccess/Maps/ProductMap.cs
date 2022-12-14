using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Restaurant.DataAccess.Entities;

namespace Restaurant.DataAccess.Maps
{
    public class ProductMap : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("Product");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id).HasColumnName("Id");
            builder.Property(x => x.ProductName).IsRequired().HasMaxLength(100).HasColumnName("ProductName");
            builder.Property(x => x.Price).IsRequired().HasColumnName("ProductPrice");
        }
    }
}
