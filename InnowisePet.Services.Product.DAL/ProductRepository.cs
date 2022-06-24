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
        IEnumerable<Product> result = new List<Product>();
        using (var cursor = await _collection.FindAsync(_ => true))
        {
            while(await cursor.MoveNextAsync())
            {
                var products = cursor.Current;
                foreach (var product in products)
                {
                    result.Append(product);
                }
            }
        }

        return result;
    }
    public async Task AddProduct(Product product)
    {
        await _collection.InsertOneAsync(product);
    }
}