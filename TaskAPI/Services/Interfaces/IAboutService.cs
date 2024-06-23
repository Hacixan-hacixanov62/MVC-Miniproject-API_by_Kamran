using TaskAPI.DTOs.Abouts;

namespace TaskAPI.Services.Interfaces
{
    public interface IAboutService
    {
        Task CreateAsync(AboutCreateDto data);
        Task EditAsync(int id, AboutEditDto data);
        Task DeleteAsync(int id);
        Task<IEnumerable<AboutDto>> GetAllAsync();
        Task<AboutDetailDto> GetByIdDetailAsync(int id);
        Task<AboutDto> GetFirstAsync();
    }
}
