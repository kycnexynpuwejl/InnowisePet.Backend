using InnowisePet.Models.Entities;

namespace InnowisePet.Services.Product.Tests;

public static class MockProductsDb
{
    public static IEnumerable<ProductModel> productModels = new List<ProductModel>()
    {
        new ProductModel(){Id = Guid.NewGuid()},
        new ProductModel(){Id = Guid.NewGuid()},
        new ProductModel(){Id = Guid.NewGuid()}
    };
    
}