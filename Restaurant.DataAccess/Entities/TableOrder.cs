namespace Restaurant.DataAccess.Entities
{
    public class TableOrder
    {
        public TableOrder()
        {
            RestaurantTable = new RestaurantTable();
            User = new DbUser();
        }

        public int Id { get; set; } 
        public int RestaurantId { get; set; }
        public int TableNumber { get; set; }
        public Guid TableOwner { get; set; }
        public bool ClosedOrder { get; set; }   

        public virtual RestaurantTable RestaurantTable { get; set; }
        public virtual DbUser User { get; set; }
    }
}
