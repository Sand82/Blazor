using IMS.CoreBusiness;
using IMS.UseCases.PluginInterfaces;

namespace IMS.Plugins.InMemory;

public class ProductRepository : IProductRepository
{
    private readonly List<Product> products;
    public ProductRepository()
    {
        this.products = new List<Product>()
        {
            new Product { ProductId = 1, ProductName = "Bike", Quantity = 10, Price = 700 },
            new Product { ProductId = 2, ProductName = "Laptop", Quantity = 5, Price = 1500 },
            new Product { ProductId = 3, ProductName = "Phone", Quantity = 20, Price = 300 },            
        };
    }

    public async Task<IEnumerable<Product>> GetProductsByNameAsync(string name)
    {
        if (string.IsNullOrWhiteSpace(name))
        {
            return await Task.FromResult(products.AsEnumerable());
        }

        return await Task.FromResult(this.products.Where(p => p.ProductName.Contains(name, StringComparison.OrdinalIgnoreCase)));
    }

    public Task<Product?> GetProductByIdAsync(int ProductId)
    {
        return Task.FromResult(this.products.FirstOrDefault(x => x.ProductId == ProductId));
    }

    public Task AddProductAsync(Product Product)
    {
        if (this.products.Any(x => x.ProductName.Equals(Product.ProductName, StringComparison.OrdinalIgnoreCase)))
        {
            return Task.CompletedTask;
        }

        var maxId = this.products.Max(x => x.ProductId);
        Product.ProductId = maxId + 1;

        products.Add(Product);
        return Task.CompletedTask;
    }

    public async Task EditProductAsync(Product Product)
    {

        if (this.products.Any(
            x => x.ProductId != Product.ProductId &&
            x.ProductName.Equals(Product.ProductName,
            StringComparison.OrdinalIgnoreCase)))
        {
            return;
        }

        Product? existingProduct = await GetProductByIdAsync(Product.ProductId);

        if (existingProduct != null)
        {
            existingProduct.ProductName = Product.ProductName;
            existingProduct.Quantity = Product.Quantity;
            existingProduct.Price = Product.Price;
        }

        return;
    }

    public Task DeleteProductByIdAsync(int productId)
    {
        var Product = products.FirstOrDefault(x => x.ProductId == productId);
        if (Product != null)
        {
            products.Remove(Product);
        }
        return Task.CompletedTask;
    }
}
