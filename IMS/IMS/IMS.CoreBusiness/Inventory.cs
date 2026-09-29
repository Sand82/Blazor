using System.ComponentModel.DataAnnotations;

namespace IMS.CoreBusiness;

public class Inventory
{
    public int InventoryId { get; set; }

    [Required]
    [StringLength(150, ErrorMessage = "Inventory name cannot exceed 150 characters.")]    
    public string InventoryName { get; set; } = string.Empty;

    [Range(0, int.MaxValue, ErrorMessage = "Quantity must be greater or equal to 0.")]
    public int Quantity { get; set; }

    [Range(0, double.MaxValue, ErrorMessage = "Price must be greater or equal to 0.")]
    public decimal Price { get; set; }
}
