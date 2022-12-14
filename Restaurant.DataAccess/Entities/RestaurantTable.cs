namespace Restaurant.DataAccess.Entities
{
    public class RestaurantTable
    {
        public RestaurantTable()
        {
            Restaurant = new DbRestaurant();
        }

        public int RestaurantId { get; set; }
        public int TableNumber { get; set; }
        public bool HasActiveOrder { get; set; }

        public virtual DbRestaurant Restaurant { get; set; }
    }
}
