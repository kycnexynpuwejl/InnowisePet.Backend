using InnowisePet.Models.Entities;

namespace InnowisePet.Services.Product.DAL.Repository;

public interface IProductRepository
{
    Task<IEnumerable<ProductModel>> GetProductsAsync();
    
    Task<ProductModel> GetProductByIdAsync(Guid id);
    
    Task<Guid> CreateProductAsync(ProductModel productModel);
    
    Task UpdateProductAsync(ProductModel productModel);
    
    Task DeleteProductAsync(Guid id);
    
    Task<IEnumerable<CategoryModel>> GetCategoriesAsync();

    Task<CategoryModel> GetCategoryByIdAsync(Guid id);

    Task CreateCategoryAsync(CategoryModel categoryModel);

    Task UpdateCategoryAsync(CategoryModel categoryModel);

    Task DeleteCategoryAsync(Guid id);
}