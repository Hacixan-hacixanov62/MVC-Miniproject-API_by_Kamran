using AutoMapper;
using Microsoft.EntityFrameworkCore;
using TaskAPI.Data;
using TaskAPI.DTOs.Settings;
using TaskAPI.Services.Interfaces;

namespace TaskAPI.Services
{
    public class SettingService : ISettingService
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public SettingService(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task EditAsync(int id, SettingEditDto data)
        {
            var setting = await _context.Settings.AsNoTracking().FirstOrDefaultAsync(m => m.Id == id);

            _mapper.Map(data, setting);
            _context.Settings.Update(setting);
            await _context.SaveChangesAsync();
        }

        public async Task<Dictionary<string, string>> GetAllAsync()
        {
            return await _context.Settings
                .AsNoTracking()
                .ToDictionaryAsync(m => m.Key, m => m.Value);
        }
    }
}
