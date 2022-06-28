using Microsoft.Extensions.Configuration;
using MongoDB.Driver;

namespace InnowisePet.Services.Product.DAL;

public class ProductRepository : IProductRepository
{
    private readonly IMongoCollection<Product> _collection;
    public ProductRepository(IConfiguration configuration)
    {
        var mongo = configuration.GetSection("MongoDb");
        MongoClient client = new(mongo["Connection"]);
        IMongoDatabase productDb = client.GetDatabase(mongo["Database"]);
        _collection = productDb.GetCollection<Product>(mongo["Collection"]);
    }

    public async Task<IEnumerable<Product>> GetProductsAsync()
    {
        return await _collection.AsQueryable().ToListAsync();
    }
    public async Task AddProductAsync(Product product)
    {
        await _collection.InsertOneAsync(product);
    }

    public async Task UpdateProductAsync(Product product)
    {
        await _collection.ReplaceOneAsync(p => p.Id == product.Id, product);
    }

    public async Task DeleteProductAsync(string id)
    {
        await _collection.DeleteOneAsync(p => p.Id == id);
    }
}