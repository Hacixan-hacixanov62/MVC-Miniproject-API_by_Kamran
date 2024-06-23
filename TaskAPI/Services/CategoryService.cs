using AutoMapper;
using Microsoft.EntityFrameworkCore;
using TaskAPI.Data;
using TaskAPI.DTOs.Categories;
using TaskAPI.Helpers.Extensions;
using TaskAPI.Models;
using TaskAPI.Services.Interfaces;

namespace TaskAPI.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;
        private readonly IWebHostEnvironment _env;

        public CategoryService(AppDbContext context,
                           IMapper mapper,
                           IWebHostEnvironment env)
        {
            _context = context;
            _mapper = mapper;
            _env = env;
        }

        public async Task CreateAsync(CategoryCreateDto data)
        {
            string fileName = $"{Guid.NewGuid()}-{data.UploadImage.FileName}";

            string path = _env.GenerateFilePath("images", fileName);

            await data.UploadImage.SaveFileToLocalAsync(path);

            data.Image = fileName;

            await _context.Categories.AddAsync(_mapper.Map<Category>(data));

            await _context.SaveChangesAsync();
        }

        public async Task EditAsync(int id, CategoryEditDto data)
        {
            var category = await _context.Categories.AsNoTracking().FirstOrDefaultAsync(m => m.Id == id);

            if (data.UploadImage is not null)
            {
                string oldPath = _env.GenerateFilePath("images", category.Image);
                oldPath.DeleteFileFromLocal();

                string fileName = $"{Guid.NewGuid()}-{data.UploadImage.FileName}";
                string newPath = _env.GenerateFilePath("images", fileName);
                await data.UploadImage.SaveFileToLocalAsync(newPath);

                data.Image = fileName;
            }

            _mapper.Map(data, category);
            _context.Categories.Update(category);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var category = await _context.Categories
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.Id == id);

            string imagePath = _env.GenerateFilePath("images", category.Image);
            imagePath.DeleteFileFromLocal();

            _context.Categories.Remove(category);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<CategoryDto>> GetAllAsync()
        {
            return _mapper.Map<IEnumerable<CategoryDto>>(await _context.Categories
                .Include(m => m.Courses)
                .AsNoTracking()
                .ToListAsync());
        }

        public async Task<CategoryDetailDto> GetByIdDetailAsync(int id)
        {
            return _mapper.Map<CategoryDetailDto>(await _context.Categories
                .Where(m=>m.Id==id)
                .Include(m=>m.Courses)
                .AsNoTracking()
                .FirstOrDefaultAsync());
        }

        public async Task<bool> ExistAsync(string name)
        {
            return await _context.Categories.AnyAsync(m => m.Name.Trim().ToLower() == name.Trim().ToLower());
        }

        public async Task<bool> ExistExceptByIdAsync(int id, string name)
        {
            return await _context.Categories.AnyAsync(m => m.Name.Trim().ToLower() == name.Trim().ToLower() && m.Id != id);
        }
    }
}
