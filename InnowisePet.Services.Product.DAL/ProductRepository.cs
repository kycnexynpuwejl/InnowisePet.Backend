using MongoDB.Driver;

namespace InnowisePet.Services.Product.DAL;

public class ProductRepository : IProductRepository
{
    private readonly IMongoCollection<Product> _collection;

    public ProductRepository()
    {
        MongoClient client = new("mongodb://localhost:27017");
        IMongoDatabase productDb = client.GetDatabase("product");
        _collection = productDb.GetCollection<Product>("product_collection");
    }

    public async Task<IEnumerable<Product>> GetProductsAsync()
    {
        var result = await _collection.AsQueryable().ToListAsync();
        return result;
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