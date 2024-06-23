using AutoMapper;
using Microsoft.EntityFrameworkCore;
using TaskAPI.Data;
using TaskAPI.DTOs.Courses;
using TaskAPI.DTOs.Students;
using TaskAPI.Helpers.Extensions;
using TaskAPI.Models;
using TaskAPI.Services.Interfaces;

namespace TaskAPI.Services
{
    public class StudentService : IStudentService
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;
        private readonly IWebHostEnvironment _env;

        public StudentService(AppDbContext context, IMapper mapper, IWebHostEnvironment env)
        {
            _context = context;
            _mapper = mapper;
            _env = env;
        }

        public async Task CreateAsync(StudentCreateDto data)
        {
            string fileName = $"{Guid.NewGuid()}-{data.UploadImage.FileName}";

            string path = _env.GenerateFilePath("images", fileName);

            await data.UploadImage.SaveFileToLocalAsync(path);

            data.Image = fileName;

            Student student = _mapper.Map<Student>(data);

            student.CourseStudents.Add(new CourseStudent
            {
                CourseId = data.CourseId,
                StudentId = student.Id
            });

            await _context.Students.AddAsync(student);

            await _context.SaveChangesAsync();
        }

        public async Task EditAsync(int id, StudentEditDto data)
        {
            var student = await _context.Students.AsNoTracking().FirstOrDefaultAsync(m => m.Id == id);

            if (data.UploadImage is not null)
            {
                string oldPath = _env.GenerateFilePath("images", student.Image);
                oldPath.DeleteFileFromLocal();

                string fileName = $"{Guid.NewGuid()}-{data.UploadImage.FileName}";
                string newPath = _env.GenerateFilePath("images", fileName);
                await data.UploadImage.SaveFileToLocalAsync(newPath);

                data.Image = fileName;
            }

            _mapper.Map(data, student);
            _context.Students.Update(student);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var student = await _context.Students.AsNoTracking().FirstOrDefaultAsync(m => m.Id == id);

            string imagePath = _env.GenerateFilePath("images", student.Image);
            imagePath.DeleteFileFromLocal();

            _context.Students.Remove(student);
            await _context.SaveChangesAsync();
        }

        public async Task AddCourseAsync(CourseStudentAddDto data)
        {
            await _context.CourseStudents.AddAsync(_mapper.Map<CourseStudent>(data));
            await _context.SaveChangesAsync();
        }

        public async Task DeleteCourseAsync(int courseStudentId)
        {
            var courseStudent = await _context.CourseStudents.AsNoTracking().FirstOrDefaultAsync(m => m.Id == courseStudentId);

            _context.CourseStudents.Remove(courseStudent);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<StudentDto>> GetAllAsync()
        {
            return _mapper.Map<IEnumerable<StudentDto>>(await _context.Students
                .AsNoTracking()
                .ToListAsync());
        }

        public async Task<StudentDetailDto> GetByIdDetailAsync(int id)
        {
            return _mapper.Map<StudentDetailDto>(await _context.Students
                .Where(m => m.Id == id)
                .Include(m => m.CourseStudents)
                .ThenInclude(m => m.Course)
                .AsNoTracking()
                .FirstOrDefaultAsync());
        }
    }
}
