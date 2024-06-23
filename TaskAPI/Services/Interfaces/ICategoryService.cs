using TaskAPI.DTOs.Categories;

namespace TaskAPI.Services.Interfaces
{
    public interface ICategoryService
    {
        Task CreateAsync(CategoryCreateDto data);
        Task EditAsync(int id, CategoryEditDto data);
        Task DeleteAsync(int id);
        Task<IEnumerable<CategoryDto>> GetAllAsync();
        Task<CategoryDetailDto> GetByIdDetailAsync(int id);
        Task<bool> ExistAsync(string name);
        Task<bool> ExistExceptByIdAsync(int id, string name);
    }
}
