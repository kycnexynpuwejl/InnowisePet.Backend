using AutoMapper;
using InnowisePet.Models.DTO.Product;
using InnowisePet.Models.Entities;
using InnowisePet.Services.Product.BLL.Profiles;
using InnowisePet.Services.Product.BLL.Services;
using InnowisePet.Services.Product.DAL.Repository;
using Moq;

namespace InnowisePet.Services.Product.Tests;

public class ProductServiceTests
{
    private readonly IProductService _mockProductService;
    private readonly Mock<IProductRepository> _mockProductRepo = new ();
    private readonly IMapper _mapper;

    public ProductServiceTests()
    {
        MapperConfiguration mockMapper = new(cfg =>
        {
            cfg.AddProfile(new ProductGetProfile());
            cfg.AddProfile(new ProductCreateProfile());
        });
        
        _mapper = mockMapper.CreateMapper();
        
        _mockProductService = new ProductService(_mockProductRepo.Object, _mapper);
    }

    public static IEnumerable<object[]> Uids =>
        new List<object[]>
        {
            new object[] { Guid.Empty },
            new object[] { Guid.NewGuid() },
            new object[] { Guid.NewGuid() },
            new object[] { Guid.NewGuid() },
            new object[] { Guid.NewGuid() },
            new object[] { Guid.NewGuid() },
        };

    [Theory]
    [MemberData(nameof(Uids))]
    public async Task GetProductByIdAsync_WithValidUids_ShouldBeTrue(Guid productId)
    {
        //Arrange
        _mockProductRepo.Setup(x => x.GetProductByIdAsync(It.IsAny<Guid>())).ReturnsAsync(new ProductModel() {Id = productId});
        //Act
        ProductGetDto product = await _mockProductService.GetProductByIdAsync(productId);
        
        //Assert
        Assert.Equal(productId, product.Id);
    }
    
    [Theory]
    [MemberData(nameof(Uids))]
    public async Task GetProductByIdAsync_WithNotValidUids_ShouldBeFalse(Guid productId)
    {
        //Arrange
        _mockProductRepo.Setup(x => x.GetProductByIdAsync(It.IsAny<Guid>())).ReturnsAsync(new ProductModel() {Id = Guid.NewGuid()});
        //Act
        ProductGetDto product = await _mockProductService.GetProductByIdAsync(productId);
        
        //Assert
        Assert.NotEqual(productId, product.Id);
    }
    
    public static IEnumerable<object[]> ProductModelList =>
        new List<object[]>
        {
            new object[]
            {
                new List<ProductModel>
                {
                    new() {Id = Guid.NewGuid(), Title = new string('a', 5), CategoryId = Guid.NewGuid()},
                    new() {Id = Guid.NewGuid(), Title = new string('a', 5), CategoryId = Guid.NewGuid()},
                    new() {Id = Guid.NewGuid(), Title = new string('a', 5), CategoryId = Guid.NewGuid()}
                }
            }
        };

    [Theory]
    [MemberData(nameof(ProductModelList))]
    public async Task GetProductsAsync_ShouldBeTrue(List<ProductModel> list)
    {
        //Arrange
        _mockProductRepo.Setup(x => x.GetProductsAsync()).ReturnsAsync(list);

        //Act
        IEnumerable<ProductGetDto> listDto = await _mockProductService.GetProductsAsync();
        var mappedResult = _mapper.Map<IEnumerable<ProductGetDto>>(list);
        
        //Assert
        AssertHelper.EqualCollections(listDto, mappedResult);
    }

    public static IEnumerable<object[]> ProductCreateDtoList =>
        new List<object[]>
        {
            new object[] { new ProductCreateDto() },
            new object[] { new ProductCreateDto() },
            new object[] { new ProductCreateDto() }
        };
    
    [Theory]
    [MemberData(nameof(ProductCreateDtoList))]
    public async Task CreateProductAsync_ShouldReturnCreatedProductId(ProductCreateDto productCreateDto)
    {
        //Arrange
        var mappedProduct = _mapper.Map<ProductModel>(productCreateDto);
        _mockProductRepo.Setup(x => x.CreateProductAsync(mappedProduct)).ReturnsAsync(mappedProduct.Id);

        //Act
        Guid result = await _mockProductService.CreateProductAsync(productCreateDto);
        
        //Assert
        Assert.Equal(result, mappedProduct.Id);
    }
}