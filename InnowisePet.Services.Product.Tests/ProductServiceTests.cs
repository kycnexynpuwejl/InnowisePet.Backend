using AutoMapper;
using InnowisePet.Models.DTO.Product;
using InnowisePet.Models.Entities;
using InnowisePet.Services.Product.BLL.Services;
using InnowisePet.Services.Product.DAL.Repository;
using Moq;

namespace InnowisePet.Services.Product.Tests;

public class ProductServiceTests
{
    private readonly IProductService _productServiceMock;
    private readonly IProductRepository _productRepoMock = new MockProductRepository();
    private readonly Mock<IMapper> _mapper = new Mock<IMapper>();

    public ProductServiceTests()
    {
        _productServiceMock = new ProductService(_productRepoMock, _mapper.Object);
    }

    [Fact]
    public async Task GetProductByIdAsync_ShouldReturnProductExists()
    {
        //Arrange
        var productId = Guid.NewGuid();
        
        var product = new ProductModel() { Id = productId };

        //Act
        ProductGetDto productDto = await _productServiceMock.GetProductByIdAsync(productId);
        
        //Assert
        Assert.Equal(productId, productDto.Id);
    }
    
    [Fact]
    public async Task GetProductsAsync_ShouldReturnProductsExists()
    {
        //Arrange
        
        
        //Act
       
        
        //Assert
        Assert.Equal(3, _productRepoMock.GetProductsAsync().Result.Count());
    }
}