using InnowisePet.Models.Entities;
using InnowisePet.Services.Product.DAL.Data;
using Microsoft.EntityFrameworkCore;

namespace InnowisePet.Services.Product.DAL.Repository;

public class ProductRepository : IProductRepository
{
    private readonly ProductDbContext _context;
    
    public ProductRepository(ProductDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<ProductModel>> GetProductsAsync()
    {
        return await _context.Products.Include(c => c.Category).ToListAsync();
    }

    public async Task<ProductModel> GetProductByIdAsync(Guid id)
    {
        return await _context.Products.FirstOrDefaultAsync(p => p.Id == id);
    }

    public async Task<IEnumerable<CategoryModel>> GetCategoriesAsync()
    {
        return await _context.Categories.ToListAsync();
    }

    public async Task<CategoryModel> GetCategoryByIdAsync(Guid id)
    {
        return await _context.Categories.Include(c => c.Products).FirstOrDefaultAsync(c => c.Id == id);
    }

    public async Task<Guid> CreateProductAsync(ProductModel productModel)
    {
        if (productModel == null) return default;
        
        await _context.Products.AddAsync(productModel);
        await _context.SaveChangesAsync();

        return productModel.Id;
    }

    public async Task CreateCategoryAsync(CategoryModel categoryModel)
    {
        if(categoryModel == null) return;

        await _context.Categories.AddAsync(categoryModel);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateProductAsync(ProductModel productModel)
    {
        if (productModel == null) return;
        
        ProductModel productFromDb = await _context.Products.FirstOrDefaultAsync(p => p.Id == productModel.Id);

        if (productFromDb != null)
        {
            productFromDb.CategoryId = productModel.CategoryId;
            productFromDb.Title = productModel.Title;
            productFromDb.Description = productModel.Description;
            productFromDb.Price = productModel.Price;
            productFromDb.ImageUrl = productModel.ImageUrl;
        }

        await _context.SaveChangesAsync();
    }

    public async Task UpdateCategoryAsync(CategoryModel categoryModel)
    {
        if(categoryModel == null) return;

        CategoryModel categoryFromDb = await _context.Categories.FirstOrDefaultAsync(c => c.Id == categoryModel.Id);

        if (categoryFromDb != null) categoryFromDb.Title = categoryModel.Title;

        await _context.SaveChangesAsync();
    }

    public async Task DeleteProductAsync(Guid id)
    {
        var product = await _context.Products.FirstOrDefaultAsync(p => p.Id == id);
        
        if (product != null) _context.Products.Remove(product);

        await _context.SaveChangesAsync();
    }

    public async Task DeleteCategoryAsync(Guid id)
    {
        var category = await _context.Categories.FirstOrDefaultAsync(c => c.Id == id);

        if (category != null) _context.Categories.Remove(category);

        await _context.SaveChangesAsync();
    }
}