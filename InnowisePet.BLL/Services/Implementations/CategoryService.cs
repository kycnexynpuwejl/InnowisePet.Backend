using AutoMapper;
using InnowisePet.BLL.Services.Interfaces;
using InnowisePet.DAL.Repo.Interfaces;
using InnowisePet.DTO.DTO;
using InnowisePet.DTO.DTO.Category;
using InnowisePet.Models.Entities;

namespace InnowisePet.BLL.Services.Implementations;

public class CategoryService : ICategoryService
{
    private readonly ICategoryRepository _categoryRepository;
    private readonly IMapper _mapper;
    
    public CategoryService(ICategoryRepository categoryRepository, IMapper mapper)
    {
        _categoryRepository = categoryRepository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<Category>> GetCategoriesAsync()
    {
        return await _categoryRepository.GetCategoriesAsync();
    }

    public async Task<Category> GetCategoryByIdAsync(Guid id)
    {
        return await _categoryRepository.GetCategoryByIdAsync(id);
    }

    public async Task<bool> CreateCategoryAsync(CategoryCreateDto categoryCreateDto)
    {
        Category category = _mapper.Map<Category>(categoryCreateDto);

        return await _categoryRepository.CreateCategoryAsync(category);
    }

    public async Task<bool> UpdateCategoryAsync(Guid id, CategoryUpdateDto categoryUpdateDto)
    {
        Category category = _mapper.Map<Category>(categoryUpdateDto);

        return await _categoryRepository.UpdateCategoryAsync(id, category);
    }

    public async Task<bool> DeleteCategoryAsync(Guid id)
    {
        return await _categoryRepository.DeleteCategoryAsync(id);
    }
}