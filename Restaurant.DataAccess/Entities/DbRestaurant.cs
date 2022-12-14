namespace Restaurant.DataAccess.Entities
{
    public class DbRestaurant
    {
        public DbRestaurant()
        {
            this.RestaurantName = string.Empty;
        }

        public int Id { get; set; }
        public string RestaurantName { get; set; }
        public int NumberOfTables { get; set; }
    }
}
