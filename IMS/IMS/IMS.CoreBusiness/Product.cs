using System.ComponentModel.DataAnnotations;

namespace IMS.CoreBusiness;

public class Product
{
    public int ProductId { get; set; }

    [Required]
    [StringLength(150, ErrorMessage = "Product name cannot exceed 150 characters.")]
    public string ProductName { get; set; } = string.Empty;

    [Range(0, int.MaxValue, ErrorMessage = "Quantity must be greater or equal to 0.")]
    public int Quantity { get; set; }

    [Range(0, double.MaxValue, ErrorMessage = "Price must be greater or equal to 0.")]
    public decimal Price { get; set; }
}
