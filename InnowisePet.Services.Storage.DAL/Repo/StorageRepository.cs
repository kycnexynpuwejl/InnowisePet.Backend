using InnowisePet.Services.Storage.DAL.Data;
using InnowisePet.Services.Storage.DAL.Models;
using Microsoft.EntityFrameworkCore;


namespace InnowisePet.Services.Storage.DAL.Repo;

public class StorageRepository : IStorageRepository
{
    private readonly StorageDbContext _context;

    public StorageRepository(StorageDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Models.Storage>> GetStoragesAsync()
    {
        return await _context.Storages.ToListAsync();
    }

    public async Task<Models.Storage> GetStorageByIdAsync(Guid id)
    {
        return await _context.Storages.Include(s => s.ProductStorages).FirstOrDefaultAsync(s => s.Id == id);
    }

    public async Task CreateStorageAsync(Models.Storage storage)
    {
        await _context.Storages.AddAsync(storage);
        await _context.SaveChangesAsync();
    }

    public async Task AddProductToStorageAsync(ProductStorage productStorage)
    {
        var productStorageFromDb = await _context.ProductStorages.FirstOrDefaultAsync(
            ps => ps.ProductId == productStorage.ProductId &&
                  ps.StorageId == productStorage.StorageId);
        if (productStorageFromDb == null)
        {
            await _context.ProductStorages.AddAsync(productStorage);
        }
        else
        {
            productStorageFromDb.Quantity += productStorage.Quantity;
        }
        await _context.SaveChangesAsync();
    }

    public async Task<IEnumerable<ProductStorage>> GetProductsAsync()
    {
        return await _context.ProductStorages.ToListAsync();
    }

    public async Task<IEnumerable<ProductStorage>> GetProductsByStorageIdAsync(Guid storageId)
    {
        return await _context.ProductStorages.Where(x => x.StorageId == storageId).ToListAsync();
    }

    public async Task DeleteProductSorageAsync(Guid storageId, Guid productId)
    {
        var productStorageToDelete = await _context.ProductStorages.FirstOrDefaultAsync(x => 
            x.StorageId == storageId &&
            x.ProductId == productId);
        
        if(productStorageToDelete == null) return;

        _context.ProductStorages.Remove(productStorageToDelete);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateProductStorageAsync(ProductStorage productStorage)
    {
        var productStorageToUpdate = await _context.ProductStorages.FirstOrDefaultAsync(ps =>
            ps.StorageId == productStorage.StorageId &&
            ps.ProductId == productStorage.ProductId);

        if (productStorageToUpdate == null) return;

        productStorageToUpdate.Quantity = productStorage.Quantity;
        _context.ProductStorages.Update(productStorageToUpdate);
        await _context.SaveChangesAsync();
    }
}