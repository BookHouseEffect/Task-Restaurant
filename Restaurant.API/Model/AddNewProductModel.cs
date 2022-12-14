using System.ComponentModel.DataAnnotations;

namespace Restaurant.API.Model
{
    public class AddNewProductModel
    {
        public AddNewProductModel()
        {
            ProductName = string.Empty;
        }

        [Required(AllowEmptyStrings = false)]
        [MaxLength(100)]
        public string ProductName { get; set; }

        [Required]
        [Range(1, double.MaxValue)]
        public double Price { get; set; }
    }
}
