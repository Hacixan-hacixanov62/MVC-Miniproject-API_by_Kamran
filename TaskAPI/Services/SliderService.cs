using AutoMapper;
using Microsoft.EntityFrameworkCore;
using TaskAPI.Data;
using TaskAPI.DTOs.Sliders;
using TaskAPI.Helpers.Extensions;
using TaskAPI.Models;
using TaskAPI.Services.Interfaces;

namespace TaskAPI.Services
{
    public class SliderService : ISliderService
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;
        private readonly IWebHostEnvironment _env;

        public SliderService(AppDbContext context,
                           IMapper mapper,
                           IWebHostEnvironment env)
        {
            _context = context;
            _mapper = mapper;
            _env = env;
        }

        public async Task CreateAsync(SliderCreateDto data)
        {
            string fileName = $"{Guid.NewGuid()}-{data.UploadImage.FileName}";

            string path = _env.GenerateFilePath("images", fileName);

            await data.UploadImage.SaveFileToLocalAsync(path);

            data.Image = fileName;

            await _context.Sliders.AddAsync(_mapper.Map<Slider>(data));

            await _context.SaveChangesAsync();
        }

        public async Task EditAsync(int id, SliderEditDto data)
        {
            var slider = await _context.Sliders.AsNoTracking().FirstOrDefaultAsync(m => m.Id == id);

            if (data.UploadImage is not null)
            {
                string oldPath = _env.GenerateFilePath("images", slider.Image);
                oldPath.DeleteFileFromLocal();

                string fileName = $"{Guid.NewGuid()}-{data.UploadImage.FileName}";
                string newPath = _env.GenerateFilePath("images", fileName);
                await data.UploadImage.SaveFileToLocalAsync(newPath);

                data.Image = fileName;
            }

            _mapper.Map(data, slider);
            _context.Sliders.Update(slider);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var slider = await _context.Sliders.AsNoTracking().FirstOrDefaultAsync(m => m.Id == id);

            string imagePath = _env.GenerateFilePath("images", slider.Image);
            imagePath.DeleteFileFromLocal();

            _context.Sliders.Remove(slider);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<SliderDto>> GetAllAsync()
        {
            return _mapper.Map<IEnumerable<SliderDto>>(await _context.Sliders.AsNoTracking().ToListAsync());
        }

        public async Task<SliderDetailDto> GetByIdDetailAsync(int id)
        {
            return _mapper.Map<SliderDetailDto>(await _context.Sliders.AsNoTracking().FirstOrDefaultAsync(m => m.Id == id));
        }
    }
}
