using InnowisePet.Models.Entities;

namespace InnowisePet.Services.Product.DAL.Repository;

public interface IProductRepository
{
    Task<IEnumerable<ProductModel>> GetProductsAsync();
    Task<ProductModel> GetProductByIdAsync(Guid id);
    Task<IEnumerable<CategoryModel>> GetCategoriesAsync();
    Task CreateProductAsync(ProductModel productModel);
    Task CreateCategoryAsync(CategoryModel categoryModel);
    Task UpdateProductAsync(ProductModel productModel);
    Task DeleteProductAsync(Guid id);
}