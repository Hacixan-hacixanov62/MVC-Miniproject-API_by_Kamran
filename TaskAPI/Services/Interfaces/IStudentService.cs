using TaskAPI.DTOs.Courses;
using TaskAPI.DTOs.Students;

namespace TaskAPI.Services.Interfaces
{
    public interface IStudentService
    {
        Task CreateAsync(StudentCreateDto data);
        Task EditAsync(int id, StudentEditDto data);
        Task DeleteAsync(int id);
        Task AddCourseAsync(CourseStudentAddDto data);
        Task DeleteCourseAsync(int courseStudentId);
        Task<IEnumerable<StudentDto>> GetAllAsync();
        Task<StudentDetailDto> GetByIdDetailAsync(int id);
    }
}
