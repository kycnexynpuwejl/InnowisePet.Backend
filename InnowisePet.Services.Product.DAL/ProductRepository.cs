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

    public async Task<IEnumerable<Product>> GetProducts()
    {
        var result = await _collection.AsQueryable().ToListAsync();
        return result;
    }
    public async Task AddProduct(Product product)
    {
        await _collection.InsertOneAsync(product);
    }
}