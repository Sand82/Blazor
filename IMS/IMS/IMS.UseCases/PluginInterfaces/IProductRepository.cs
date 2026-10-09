using IMS.CoreBusiness;

namespace IMS.UseCases.PluginInterfaces;

public interface IProductRepository
{
    Task<IEnumerable<Product>> GetProductsByNameAsync(string name);
    Task AddProductAsync(Product Product);
    Task EditProductAsync(Product Product);
    Task<Product?> GetProductByIdAsync(int ProductId);
    Task DeleteProductByIdAsync(int ProductId);
}
