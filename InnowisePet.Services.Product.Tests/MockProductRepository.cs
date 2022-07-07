using InnowisePet.Models.Entities;
using InnowisePet.Services.Product.DAL.Repository;

namespace InnowisePet.Services.Product.Tests;

public class MockProductRepository : IProductRepository
{
    public Task<IEnumerable<ProductModel>> GetProductsAsync()
    {
        return Task.FromResult<IEnumerable<ProductModel>>(MockProductsDb.productModels.ToList());
    }

    public Task<ProductModel> GetProductByIdAsync(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task CreateProductAsync(ProductModel productModel)
    {
        throw new NotImplementedException();
    }

    public Task UpdateProductAsync(ProductModel productModel)
    {
        throw new NotImplementedException();
    }

    public Task DeleteProductAsync(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<CategoryModel>> GetCategoriesAsync()
    {
        throw new NotImplementedException();
    }

    public Task<CategoryModel> GetCategoryByIdAsync(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task CreateCategoryAsync(CategoryModel categoryModel)
    {
        throw new NotImplementedException();
    }

    public Task UpdateCategoryAsync(CategoryModel categoryModel)
    {
        throw new NotImplementedException();
    }

    public Task DeleteCategoryAsync(Guid id)
    {
        throw new NotImplementedException();
    }
}