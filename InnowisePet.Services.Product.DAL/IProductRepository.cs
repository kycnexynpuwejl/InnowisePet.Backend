namespace InnowisePet.Services.Product.DAL;

public interface IProductRepository
{
    Task<IEnumerable<Product>> GetProductsAsync();
    Task AddProductAsync(Product product);
    Task UpdateProductAsync(Product product);
    Task DeleteProductAsync(string id);
}