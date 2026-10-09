using IMS.CoreBusiness;
using IMS.UseCases.PluginInterfaces;

namespace IMS.Plugins.InMemory;

public class InventoryRepository : IInventoryRepository
{
    private List<Inventory> inventories;

    public InventoryRepository()
    {
        this.inventories = new List<Inventory>()
        {
            new Inventory { InventoryId = 1, InventoryName = "Bike Seats", Quantity = 10, Price = 2 },
            new Inventory { InventoryId = 2, InventoryName = "Bike Body", Quantity = 10, Price = 50 },
            new Inventory { InventoryId = 3, InventoryName = "Bike Wheels", Quantity = 20, Price = 8 },
            new Inventory { InventoryId = 4, InventoryName = "Bike Pedals", Quantity = 20, Price = 1 },            
        };
    }

    public async Task<IEnumerable<Inventory>> GetInventoriesByNameAsync(string name)
    {
        if (string.IsNullOrWhiteSpace(name))
        {
            return await Task.FromResult(inventories.AsEnumerable());
        }

        return await Task.FromResult(this.inventories.Where(i => i.InventoryName.Contains(name, StringComparison.OrdinalIgnoreCase)));
    }

    public Task<Inventory?> GetInventoryByIdAsync(int inventoryId)
    {
        return Task.FromResult(this.inventories.FirstOrDefault(x => x.InventoryId == inventoryId));
    }

    public Task AddInventoryAsync(Inventory inventory)
    {
        if (this.inventories.Any(x => x.InventoryName.Equals(inventory.InventoryName, StringComparison.OrdinalIgnoreCase)))
        {
            return Task.CompletedTask;
        }

        var maxId = this.inventories.Max(x => x.InventoryId);
        inventory.InventoryId = maxId + 1;

        inventories.Add(inventory);
        return Task.CompletedTask;
    }        

    public async Task EditInventoryAsync(Inventory inventory)
    {

        if (this.inventories.Any(
            x => x.InventoryId != inventory.InventoryId && 
            x.InventoryName.Equals(inventory.InventoryName, 
            StringComparison.OrdinalIgnoreCase)))
        {
            return;
        }

        Inventory? existingInventory = await GetInventoryByIdAsync(inventory.InventoryId);

        if (existingInventory != null)
        {
            existingInventory.InventoryName = inventory.InventoryName;
            existingInventory.Quantity = inventory.Quantity;
            existingInventory.Price = inventory.Price;
        }

        return;
    }

    public Task DeleteInventoryByIdAsync(int inventoryId)
    {
       var inventory = inventories.FirstOrDefault(x => x.InventoryId == inventoryId);
        if (inventory != null)
        {
            inventories.Remove(inventory);
        }
        return Task.CompletedTask;
    }    
}
