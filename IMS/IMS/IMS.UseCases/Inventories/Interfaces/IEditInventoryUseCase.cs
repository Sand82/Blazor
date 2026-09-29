using IMS.CoreBusiness;

namespace IMS.UseCases.Inventories.Interfaces
{
    public interface IEditInventoryUseCase
    {
        Task ExecuteAsync(Inventory inventory);

        Task<Inventory> FindInventoryByIdAsync(int inventoryId);
    }
}