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
        return await _context.Products.ToListAsync();
    }

    public async Task<ProductModel> GetProductByIdAsync(Guid id)
    {
        return await _context.Products.FirstOrDefaultAsync(p => p.Id == id);
    }

    public async Task CreateProductAsync(ProductModel productModel)
    {
        if (productModel == null) return;
        
        await _context.Products.AddAsync(productModel);
        await _context.SaveChangesAsync();
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

        var productFromDb = await _context.Products.FirstOrDefaultAsync(p => p.Id == productModel.Id);

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

    public async Task DeleteProductAsync(Guid id)
    {
        var product = await _context.Products.FirstOrDefaultAsync(p => p.Id == id);
        
        if (product != null) _context.Products.Remove(product);

        await _context.SaveChangesAsync();
    }
    
}