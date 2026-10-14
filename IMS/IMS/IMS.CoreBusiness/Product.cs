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

    public List<ProductInventory> ProductInventories { get; set; } = new List<ProductInventory>();

    public void AddInventory(Inventory inventory)
    {
        var existingProduct = this.ProductInventories.FirstOrDefault(x => x.Inventory!.InventoryName.Equals(inventory.InventoryName));

        if (!this.ProductInventories.Any(x => 
            x.Inventory?.InventoryName is not null && 
            x.Inventory.InventoryName.Equals(inventory.InventoryName)))
        {
            this.ProductInventories.Add(new ProductInventory
            {
                InventoryId = inventory.InventoryId,
                Inventory = inventory,
                ProductId = this.ProductId,
                Product = this
            });
        }        
    }

    public void RemoveInventory(ProductInventory productInventory)
    {
        this.ProductInventories.Remove(productInventory);
    }
}
