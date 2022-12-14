namespace Restaurant.DataAccess.Entities
{
    public class TableOrderItem
    {
        public TableOrderItem()
        {
            TableOrder = new TableOrder();
            Product = new Product();
        }

        public int Id { get; set; }
        public int TableOrderId { get; set; }
        public int ProductId { get; set; }
        public double ProductPrice { get; set; }
        public double ProductQuantity { get; set; }
        public double ItemSum { get; set; }

        public virtual TableOrder TableOrder { get; set; }
        public virtual Product Product { get; set; }
    }
}
