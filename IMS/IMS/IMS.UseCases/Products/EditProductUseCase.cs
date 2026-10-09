using IMS.CoreBusiness;
using IMS.UseCases.PluginInterfaces;
using IMS.UseCases.Products.Interfaces;

public class EditProductUseCase : IEditProductUseCase
{
    private readonly IProductRepository productRepository;

    public EditProductUseCase(IProductRepository productRepository)
    {
        this.productRepository = productRepository;
    }

    public async Task ExecuteAsync(Product product)
    {
        await this.productRepository.EditProductAsync(product);
    }
}
