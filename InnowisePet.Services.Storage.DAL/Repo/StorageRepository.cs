using InnowisePet.Models.Entities;
using InnowisePet.Services.Storage.DAL.Data;
using Microsoft.EntityFrameworkCore;


namespace InnowisePet.Services.Storage.DAL.Repo;

public class StorageRepository : IStorageRepository
{
    private readonly StorageDbContext _context;

    public StorageRepository(StorageDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<InnowisePet.Models.Entities.StorageModel>> GetStoragesAsync()
    {
        return await _context.Storages.ToListAsync();
    }

    public async Task<InnowisePet.Models.Entities.StorageModel> GetStorageByIdAsync(Guid id)
    {
        return await _context.Storages.Include(s => s.ProductStorages).FirstOrDefaultAsync(s => s.Id == id);
    }

    public async Task CreateStorageAsync(InnowisePet.Models.Entities.StorageModel storageModel)
    {
        await _context.Storages.AddAsync(storageModel);
        await _context.SaveChangesAsync();
    }

    public async Task AddProductToStorageAsync(ProductStorageModel productStorageModel)
    {
        var productStorageFromDb = await _context.ProductStorages.FirstOrDefaultAsync(
            ps => ps.ProductId == productStorageModel.ProductId &&
                  ps.StorageId == productStorageModel.StorageId);
        if (productStorageFromDb == null)
        {
            await _context.ProductStorages.AddAsync(productStorageModel);
        }
        else
        {
            productStorageFromDb.Quantity += productStorageModel.Quantity;
        }
        await _context.SaveChangesAsync();
    }

    public async Task<IEnumerable<ProductStorageModel>> GetProductsAsync()
    {
        return await _context.ProductStorages.ToListAsync();
    }

    public async Task<IEnumerable<ProductStorageModel>> GetProductsByStorageIdAsync(Guid storageId)
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

    public async Task UpdateProductStorageAsync(ProductStorageModel productStorageModel)
    {
        var productStorageToUpdate = await _context.ProductStorages.FirstOrDefaultAsync(ps =>
            ps.StorageId == productStorageModel.StorageId &&
            ps.ProductId == productStorageModel.ProductId);

        if (productStorageToUpdate == null) return;

        productStorageToUpdate.Quantity = productStorageModel.Quantity;
        _context.ProductStorages.Update(productStorageToUpdate);
        await _context.SaveChangesAsync();
    }
}