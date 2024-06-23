using TaskAPI.DTOs.Instructors;

namespace TaskAPI.Services.Interfaces
{
    public interface IInstructorService
    {
        Task CreateAsync(InstructorCreateDto data);
        Task EditAsync(int id, InstructorEditDto data);
        Task DeleteAsync(int id);
        Task AddSocialAsync(InstructorSocialAddDto  data);
        Task DeleteSocialAsync(int instructorSocialId);
        Task<IEnumerable<InstructorDto>> GetAllAsync();
        Task<IEnumerable<InstructorWithSocialsDto>> GetAllWithSocialsAsync();
        Task<InstructorDetailDto> GetByIdDetailAsync(int id);
    }
}
