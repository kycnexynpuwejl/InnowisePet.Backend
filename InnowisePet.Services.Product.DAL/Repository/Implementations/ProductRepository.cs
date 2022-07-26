using InnowisePet.Models.DTO.Product;
using InnowisePet.Models.Entities;
using InnowisePet.Services.Product.DAL.Data;
using InnowisePet.Services.Product.DAL.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace InnowisePet.Services.Product.DAL.Repository.Implementations;

public class ProductRepository : IProductRepository
{
    private readonly ProductDbContext _context;
    
    public ProductRepository(ProductDbContext context)
    {
        _context = context;
    }

    public async Task<PaginatedProductsDto> GetProductsAsync(ProductFilter productFilter)
    {
        var products = _context.Products
            .Include(c => c.Category)
            .Where(productFilter.Search != null ? p =>  p.Title.Contains(productFilter.Search) : p => true);
            
        var productCount = products.Count();
        
        var paginatedProducts = await products
            .Skip(--productFilter.PageNumber * productFilter.PageSize)
            .Take(productFilter.PageSize)
            .ToListAsync();

        return new PaginatedProductsDto() { ProductCount = productCount, PaginatedProducts = paginatedProducts };
    }

    public async Task<ProductModel> GetProductByIdAsync(Guid productId)
    {
        return await _context.Products.FirstOrDefaultAsync(p => p.Id == productId);
    }

    public async Task<PaginatedProductsDto> GetProductsByCategoryIdAsync(Guid categoryId, ProductFilter productFilter)
    {
        var products = _context.Products
            .Include(c => c.Category)
            .Where(p => p.CategoryId == categoryId)
            .Where(productFilter.Search != null ? p =>  p.Title.Contains(productFilter.Search) : p => true);
            
        var productCount = products.Count();
        
        var paginatedProducts = await _context.Products.FromSqlRaw(
                                            $@"SELECT *
                                                FROM [dbo].[Products]
                                                WHERE CategoryId = '{categoryId}' AND Title LIKE '%{productFilter.Search}%'
                                                ORDER BY Title
                                                OFFSET {productFilter.PageSize * (productFilter.PageNumber -1)} ROWS
                                                FETCH FIRST {productFilter.PageSize} ROWS ONLY
                                                "
                                        ).ToListAsync();
        
        return new PaginatedProductsDto() { ProductCount = productCount, PaginatedProducts = paginatedProducts };
    }

    public async Task<Guid> CreateProductAsync(ProductModel productModel)
    {
        if (productModel == null) return default;
        
        await _context.Products.AddAsync(productModel);
        await _context.SaveChangesAsync();

        return productModel.Id;
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

    public async Task DeleteProductAsync(Guid id)
    {
        ProductModel product = await _context.Products.FirstOrDefaultAsync(p => p.Id == id);
        
        if (product != null) _context.Products.Remove(product);

        await _context.SaveChangesAsync();
    }
}