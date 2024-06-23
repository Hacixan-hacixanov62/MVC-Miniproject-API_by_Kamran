using AutoMapper;
using Microsoft.EntityFrameworkCore;
using TaskAPI.Data;
using TaskAPI.DTOs.Courses;
using TaskAPI.Helpers.Extensions;
using TaskAPI.Models;
using TaskAPI.Services.Interfaces;

namespace TaskAPI.Services
{
    public class CourseService : ICourseService
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;
        private readonly IWebHostEnvironment _env;

        public CourseService(AppDbContext context,
                             IMapper mapper,
                             IWebHostEnvironment env)
        {
            _context = context;
            _mapper = mapper;
            _env = env;
        }

        public async Task CreateAsync(CourseCreateDto data)
        {
            List<CourseImage> images = new();

            foreach (var item in data.UploadImages)
            {
                string fileName = $"{Guid.NewGuid()}-{item.FileName}";

                string path = _env.GenerateFilePath("images", fileName);

                await item.SaveFileToLocalAsync(path);

                images.Add(new CourseImage { Name = fileName });
            }

            images.FirstOrDefault().IsMain = true;

            data.CourseImages = images;

            await _context.Courses.AddAsync(_mapper.Map<Course>(data));
            await _context.SaveChangesAsync();
        }

        public async Task EditAsync(int id, CourseEditDto data)
        {
            var course = await _context.Courses
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.Id == id);

            if (data.UploadImages is not null)
            {
                List<CourseImage> images = new();

                foreach (var item in data.UploadImages)
                {
                    string fileName = $"{Guid.NewGuid()}-{item.FileName}";

                    string path = _env.GenerateFilePath("images", fileName);

                    await item.SaveFileToLocalAsync(path);

                    images.Add(new CourseImage { Name = fileName });
                }

                data.CourseImages = images;
            }

            _mapper.Map(data, course);
            _context.Courses.Update(course);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var course = await _context.Courses
                .Where(m=>m.Id==id)
                .Include(course => course.CourseImages)
                .AsNoTracking()
                .FirstOrDefaultAsync();

            foreach (var item in course.CourseImages)
            {
                string path = _env.GenerateFilePath("images", item.Name);
                path.DeleteFileFromLocal();
            }

            _context.Courses.Remove(course);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<CourseDto>> GetAllPopularAsync()
        {
            var datas = await _context.Courses
                .OrderByDescending(m => m.Rating)
                .Include(m => m.CourseImages)
                .Include(m => m.Instructor)
                .Include(m => m.CourseStudents)
                .AsNoTracking()
                .ToListAsync();

            return _mapper.Map<IEnumerable<CourseDto>>(datas);
        }

        public async Task<IEnumerable<CourseAdminDto>> GetAllAsync()
        {
            return _mapper.Map<IEnumerable<CourseAdminDto>>(await _context.Courses
                .Include(m => m.CourseImages)
                .Include(m => m.Instructor)
                .Include(m => m.Category)
                .AsNoTracking()
                .ToListAsync());
        }

        public async Task<CourseDetailDto> GetByIdDetailAsync(int id)
        {
            return _mapper.Map<CourseDetailDto>(await _context.Courses
                .Where(m => m.Id == id)
                .Include(m => m.CourseImages)
                .Include(m => m.Instructor)
                .Include(m => m.Category)
                .AsNoTracking()
                .FirstOrDefaultAsync());
        }

        public async Task SetMainImageAsync(MainAndDeleteImageDto data)
        {
            var course = await _context.Courses
                .Where(m => m.Id == data.CourseId)
                .Include(m => m.CourseImages)
                .AsNoTracking()
                .FirstOrDefaultAsync();

            var courseImage = course.CourseImages.FirstOrDefault(m => m.Id == data.ImageId);

            course.CourseImages.FirstOrDefault(m => m.IsMain).IsMain = false;
            courseImage.IsMain = true;

            _context.Update(course);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteCourseImageAsync(MainAndDeleteImageDto data)
        {
            var course = await _context.Courses
                .Where(m => m.Id == data.CourseId)
                .Include(m => m.CourseImages)
                .AsNoTracking()
                .FirstOrDefaultAsync();

            var courseImage = course.CourseImages.FirstOrDefault(m => m.Id == data.ImageId);

            _context.CourseImages.Remove(courseImage);
            await _context.SaveChangesAsync();

            string path = _env.GenerateFilePath("images", courseImage.Name);
            path.DeleteFileFromLocal();
        }

        public async Task<bool> ExistAsync(string name)
        {
            return await _context.Courses.AnyAsync(m => m.Name.Trim().ToLower() == name.Trim().ToLower());
        }

        public async Task<bool> ExistExceptByIdAsync(int id, string name)
        {
            return await _context.Courses.AnyAsync(m => m.Name.Trim().ToLower() == name.Trim().ToLower() && m.Id != id);
        }
    }
}
