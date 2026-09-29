using IMS.CoreBusiness;

namespace IMS.UseCases.PluginInterfaces;

public interface IInventoryRepository
{
    public Task<IEnumerable<IMS.CoreBusiness.Inventory>> GetInventoriesByNameAsync(string name);

    public Task AddInventoryAsync(Inventory inventory);

    public Task EditInventoryAsync(Inventory inventory);

    public Task<Inventory> GetInventoryByIdAsync(int inventoryId);
}
