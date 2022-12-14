using Microsoft.EntityFrameworkCore;
using Restaurant.DataAccess.Entities;
using Restaurant.DataAccess.Maps;

namespace Restaurant.DataAccess
{
    public class DatabaseContext : DbContext
    {
        public DbSet<DbUser> Users { get; set; }
        public DbSet<DbRestaurant> Restaurants { get; set; } 
        public DbSet<Product> Products { get; set; }
        public DbSet<RestaurantTable> RestaurantTables { get; set; }
        public DbSet<TableOrder> TableOrders { get; set; }
        public DbSet<TableOrderItem> TableOrderItems { get; set; }

        public DatabaseContext(DbContextOptions<DatabaseContext> options)
        : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new UserMap());
            modelBuilder.ApplyConfiguration(new RestaurantMap());
            modelBuilder.ApplyConfiguration(new ProductMap());
            modelBuilder.ApplyConfiguration(new RestaurantTableMap());
            modelBuilder.ApplyConfiguration(new TableOrderMap());
            modelBuilder.ApplyConfiguration(new TableOrderItemMap());
        }
    }
}
