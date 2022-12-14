using System.ComponentModel.DataAnnotations;

namespace Restaurant.API.Model
{
    public class AddTableOrder
    {
        [Required]
        [Range(1, int.MaxValue)]
        public int ProductId { get; set; }

        [Required]
        [Range(0.01, double.MaxValue)]
        public double Quantity { get; set; }
    }
}
