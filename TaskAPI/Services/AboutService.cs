using AutoMapper;
using Microsoft.EntityFrameworkCore;
using TaskAPI.Data;
using TaskAPI.DTOs.Abouts;
using TaskAPI.Helpers.Extensions;
using TaskAPI.Models;
using TaskAPI.Services.Interfaces;

namespace TaskAPI.Services
{
    public class AboutService : IAboutService
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;
        private readonly IWebHostEnvironment _env;

        public AboutService(AppDbContext context,
                           IMapper mapper,
                           IWebHostEnvironment env)
        {
            _context = context;
            _mapper = mapper;
            _env = env;
        }

        public async Task CreateAsync(AboutCreateDto data)
        {
            string fileName = $"{Guid.NewGuid()}-{data.UploadImage.FileName}";

            string path = _env.GenerateFilePath("images", fileName);

            await data.UploadImage.SaveFileToLocalAsync(path);

            data.Image = fileName;

            await _context.Abouts.AddAsync(_mapper.Map<About>(data));

            await _context.SaveChangesAsync();
        }

        public async Task EditAsync(int id, AboutEditDto data)
        {
            var about = await _context.Abouts.AsNoTracking().FirstOrDefaultAsync(m => m.Id == id);

            if (data.UploadImage is not null)
            {
                string oldPath = _env.GenerateFilePath("images", about.Image);
                oldPath.DeleteFileFromLocal();

                string fileName = $"{Guid.NewGuid()}-{data.UploadImage.FileName}";
                string newPath = _env.GenerateFilePath("images", fileName);
                await data.UploadImage.SaveFileToLocalAsync(newPath);

                data.Image = fileName;
            }

            _mapper.Map(data, about);
            _context.Abouts.Update(about);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var about = await _context.Abouts.AsNoTracking().FirstOrDefaultAsync(m => m.Id == id);

            string imagePath = _env.GenerateFilePath("images", about.Image);
            imagePath.DeleteFileFromLocal();

            _context.Abouts.Remove(about);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<AboutDto>> GetAllAsync()
        {
            return _mapper.Map<IEnumerable<AboutDto>>(await _context.Abouts.AsNoTracking().ToListAsync());
        }

        public async Task<AboutDetailDto> GetByIdDetailAsync(int id)
        {
            return _mapper.Map<AboutDetailDto>(await _context.Abouts.AsNoTracking().FirstOrDefaultAsync(m => m.Id == id));
        }

        public async Task<AboutDto> GetFirstAsync()
        {
            return _mapper.Map<AboutDto>(await _context.Abouts.FirstOrDefaultAsync());
        }
    }
}
