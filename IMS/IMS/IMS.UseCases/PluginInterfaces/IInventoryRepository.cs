using IMS.CoreBusiness;

namespace IMS.UseCases.PluginInterfaces;

public interface IInventoryRepository
{
    Task<IEnumerable<IMS.CoreBusiness.Inventory>> GetInventoriesByNameAsync(string name);
    Task AddInventoryAsync(Inventory inventory);
    Task EditInventoryAsync(Inventory inventory);
    Task<Inventory?> GetInventoryByIdAsync(int inventoryId);
    Task DeleteInventoryByIdAsync(int inventoryId);
}
