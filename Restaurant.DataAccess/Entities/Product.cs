namespace Restaurant.DataAccess.Entities
{
    public class Product
    {
        public Product()
        {
            this.ProductName = string.Empty;
        }

        public int Id { get; set; }
        public string ProductName { get; set; }
        public double Price { get; set; }
    }
}
