using AutoMapper;
using Microsoft.EntityFrameworkCore;
using TaskAPI.Data;
using TaskAPI.DTOs.Instructors;
using TaskAPI.Helpers.Extensions;
using TaskAPI.Models;
using TaskAPI.Services.Interfaces;

namespace TaskAPI.Services
{
    public class InstructorService : IInstructorService
    {
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _env;
        private readonly IMapper _mapper;

        public InstructorService(AppDbContext context,
                                 IWebHostEnvironment env,
                                 IMapper mapper)
        {
            _context = context;
            _env = env;
            _mapper = mapper;
        }

        public async Task CreateAsync(InstructorCreateDto data)
        {
            string fileName = $"{Guid.NewGuid()}-{data.UploadImage.FileName}";

            string path = _env.GenerateFilePath("images", fileName);

            await data.UploadImage.SaveFileToLocalAsync(path);

            data.Image = fileName;

            await _context.Instructors.AddAsync(_mapper.Map<Instructor>(data));

            await _context.SaveChangesAsync();
        }

        public async Task EditAsync(int id, InstructorEditDto data)
        {
            var instructor = await _context.Instructors.AsNoTracking().FirstOrDefaultAsync(m => m.Id == id);

            if (data.UploadImage is not null)
            {
                string oldPath = _env.GenerateFilePath("images", instructor.Image);
                oldPath.DeleteFileFromLocal();

                string fileName = $"{Guid.NewGuid()}-{data.UploadImage.FileName}";
                string newPath = _env.GenerateFilePath("images", fileName);
                await data.UploadImage.SaveFileToLocalAsync(newPath);

                data.Image = fileName;
            }

            _mapper.Map(data, instructor);
            _context.Instructors.Update(instructor);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var instructor = await _context.Instructors.AsNoTracking().FirstOrDefaultAsync(m => m.Id == id);

            string imagePath = _env.GenerateFilePath("images", instructor.Image);
            imagePath.DeleteFileFromLocal();

            _context.Instructors.Remove(instructor);
            await _context.SaveChangesAsync();
        }

        public async Task AddSocialAsync(InstructorSocialAddDto data)
        {
            await _context.InstructorSocials.AddAsync(_mapper.Map<InstructorSocial>(data));
            await _context.SaveChangesAsync();
        }

        public async Task DeleteSocialAsync(int instructorSocialId)
        {
            var instructorSocial = await _context.InstructorSocials
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.Id == instructorSocialId);

            _context.InstructorSocials.Remove(instructorSocial);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<InstructorDto>> GetAllAsync()
        {
            return _mapper.Map<IEnumerable<InstructorDto>>(await _context.Instructors
                .AsNoTracking()
                .ToListAsync());
        }

        public async Task<IEnumerable<InstructorWithSocialsDto>> GetAllWithSocialsAsync()
        {
            return _mapper.Map<IEnumerable<InstructorWithSocialsDto>>(await _context.Instructors
                .Include(m => m.InstructorSocials)
                .ThenInclude(m => m.Social)
                .ToListAsync());
        }

        public async Task<InstructorDetailDto> GetByIdDetailAsync(int id)
        {
            return _mapper.Map<InstructorDetailDto>( await _context.Instructors
                .Where(m => m.Id == id)
                .Include(m => m.InstructorSocials)
                .ThenInclude(m => m.Social)
                .Include(m => m.Courses)
                .AsNoTracking()
                .FirstOrDefaultAsync());
        }
    }
}
