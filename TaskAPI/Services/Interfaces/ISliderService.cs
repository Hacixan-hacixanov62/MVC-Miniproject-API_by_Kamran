using TaskAPI.DTOs.Sliders;

namespace TaskAPI.Services.Interfaces
{
    public interface ISliderService
    {
        Task CreateAsync(SliderCreateDto data);
        Task EditAsync(int id, SliderEditDto data);
        Task DeleteAsync(int id);
        Task<IEnumerable<SliderDto>> GetAllAsync();
        Task<SliderDetailDto> GetByIdDetailAsync(int id);
    }
}
