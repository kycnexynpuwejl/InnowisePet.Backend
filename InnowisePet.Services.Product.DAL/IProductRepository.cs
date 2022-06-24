namespace InnowisePet.Services.Product.DAL;

public interface IProductRepository
{
    Task<IEnumerable<Product>> GetProducts();
    Task AddProduct(Product product);
}