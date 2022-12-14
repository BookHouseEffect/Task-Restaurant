namespace Restaurant.DataAccess.Entities
{
    public class DbUser
    {
        public DbUser()
        {
            this.DisplayName = string.Empty;
            this.UserName = string.Empty;
            this.Restaurant = new DbRestaurant();
        }

        public Guid Id { get; set; }
        public string DisplayName { get; set; }
        public string UserName { get; set; }
        public int WorkingAtRestaurantId { get; set; }

        public virtual DbRestaurant Restaurant { get; set; }
    }
}
