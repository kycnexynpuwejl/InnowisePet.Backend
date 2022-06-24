using MongoDB.Driver;

namespace InnowisePet.Services.Product.DAL;

public class ProductRepository
{
    private readonly IMongoCollection<Product> _collection;

    public ProductRepository(IMongoCollection<Product> collection)
    {
        MongoClient client = new("mongodb://localhost:27017");
        IMongoDatabase productDb = client.GetDatabase("product");
        _collection = productDb.GetCollection<Product>("product_collection");
    }

    public async Task AddProduct(Product product)
    {
        await _collection.InsertOneAsync(product);
    }
}