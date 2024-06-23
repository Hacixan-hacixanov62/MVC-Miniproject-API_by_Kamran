using AutoMapper;
using Microsoft.EntityFrameworkCore;
using TaskAPI.Data;
using TaskAPI.DTOs.Informations;
using TaskAPI.Models;
using TaskAPI.Services.Interfaces;

namespace TaskAPI.Services
{
    public class InformationService : IInformationService
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public InformationService(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task CreateAsync(InformationCreateDto data)
        {
            await _context.Informations.AddAsync(_mapper.Map<Information>(data));
            await _context.SaveChangesAsync();
        }

        public async Task EditAsync(int id, InformationEditDto data)
        {
            var information = await _context.Informations.AsNoTracking().FirstOrDefaultAsync(m => m.Id == id);

            _mapper.Map(data, information);
            _context.Informations.Update(information);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var information = await _context.Informations.AsNoTracking().FirstOrDefaultAsync(m => m.Id == id);

            _context.Informations.Remove(information);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<InformationDto>> GetAllAsync()
        {
            return _mapper.Map<IEnumerable<InformationDto>>(await _context.Informations
                .AsNoTracking()
                .ToListAsync());
        }

        public async Task<InformationDetailDto> GetByIdDetailAsync(int id)
        {
            return _mapper.Map<InformationDetailDto>(await _context.Informations
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.Id == id));
        }

        public async Task<bool> ExistAsync(string title)
        {
            return await _context.Informations.AnyAsync(m => m.Title.Trim().ToLower() == title.Trim().ToLower());
        }

        public async Task<bool> ExistExceptByIdAsync(int id, string title)
        {
            return await _context.Informations.AnyAsync(m => m.Title.Trim().ToLower() == title.Trim().ToLower() && m.Id != id);

        }
    }
}
