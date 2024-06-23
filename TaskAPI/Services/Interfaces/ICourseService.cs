using TaskAPI.DTOs.Courses;

namespace TaskAPI.Services.Interfaces
{
    public interface ICourseService
    {
        Task CreateAsync(CourseCreateDto data);
        Task EditAsync(int id, CourseEditDto data);
        Task DeleteAsync(int id);
        Task<IEnumerable<CourseDto>> GetAllPopularAsync();
        Task<IEnumerable<CourseAdminDto>> GetAllAsync();
        Task<CourseDetailDto> GetByIdDetailAsync(int id);
        Task SetMainImageAsync(MainAndDeleteImageDto data);
        Task DeleteCourseImageAsync(MainAndDeleteImageDto data);
        Task<bool> ExistAsync(string name);
        Task<bool> ExistExceptByIdAsync(int id, string name);
    }
}
