using InnowisePet.Models.Entities;

namespace InnowisePet.Services.Product.Tests;

public static class MockProductsDb
{
    /// <summary>
    /// Mock repo with 3 entities
    /// </summary>
    public static IEnumerable<ProductModel> productModels = new List<ProductModel>()
    {
        new ProductModel(){Id = Guid.Parse("b794d697-f037-4020-a42f-d15104ca0056")},
        new ProductModel(){Id = Guid.Parse("863be586-8377-4a4c-90d9-f5f6101bab3e")},
        new ProductModel(){Id = Guid.Parse("2e2fb97c-6a12-418a-9180-46dff0deac9a")}
    };
}