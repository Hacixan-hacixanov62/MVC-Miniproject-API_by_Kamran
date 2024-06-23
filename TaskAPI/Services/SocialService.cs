using AutoMapper;
using Microsoft.EntityFrameworkCore;
using TaskAPI.Data;
using TaskAPI.DTOs.Socials;
using TaskAPI.Models;
using TaskAPI.Services.Interfaces;

namespace TaskAPI.Services
{
    public class SocialService : ISocialService
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public SocialService(AppDbContext context,
                             IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task CreateAsync(SocialCreateDto data)
        {
            await _context.Socials.AddAsync(_mapper.Map<Social>(data));
            await _context.SaveChangesAsync();
        }

        public async Task EditAsync(int id, SocialEditDto data)
        {
            var social = await _context.Socials.AsNoTracking().FirstOrDefaultAsync(m => m.Id == id);

            _mapper.Map(data, social);

            _context.Socials.Update(social);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var social = await _context.Socials.AsNoTracking().FirstOrDefaultAsync(m => m.Id == id);

            _context.Socials.Remove(social);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<SocialDto>> GetAllAsync()
        {
            return _mapper.Map<IEnumerable<SocialDto>>(await _context.Socials.ToListAsync());
        }

        public async Task<bool> ExistAsync(string name)
        {
            return await _context.Socials.AnyAsync(m => m.Name.Trim().ToLower() == name.Trim().ToLower());
        }

        public async Task<bool> ExistExceptByIdAsync(int id, string name)
        {
            return await _context.Socials.AnyAsync(m => m.Name.Trim().ToLower() == name.Trim().ToLower() && m.Id != id);
        }
    }
}
