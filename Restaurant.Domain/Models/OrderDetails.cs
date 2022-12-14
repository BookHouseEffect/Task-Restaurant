using Restaurant.DataAccess.Entities;

namespace Restaurant.Domain.Models
{
    public class OrderDetails
    {
        public OrderDetails(TableOrder order, List<TableOrderItem> orderItem)
        {
            Order = order;
            OrderItem = orderItem;
        }

        public TableOrder Order { get; set; }
        public List<TableOrderItem> OrderItem { get; set; }
    }
}
