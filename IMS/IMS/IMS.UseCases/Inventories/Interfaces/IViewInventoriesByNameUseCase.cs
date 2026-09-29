using IMS.CoreBusiness;

namespace IMS.UseCases.Inventories.Interfaces;
public interface IViewInventoriesByNameUseCase
{
    Task<IEnumerable<IMS.CoreBusiness.Inventory>> ExecuteAsync(string name = "");
}