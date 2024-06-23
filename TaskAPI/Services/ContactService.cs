using AutoMapper;
using Microsoft.EntityFrameworkCore;
using TaskAPI.Data;
using TaskAPI.DTOs.Contacts;
using TaskAPI.Models;
using TaskAPI.Services.Interfaces;

namespace TaskAPI.Services
{
    public class ContactService : IContactService
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public ContactService(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task CreateAsync(ContactCreateDto data)
        {
            await _context.Contacts.AddAsync(_mapper.Map<Contact>(data));
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var contact = await _context.Contacts.AsNoTracking().FirstOrDefaultAsync(m => m.Id == id);

            _context.Contacts.Remove(contact);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<ContactDto>> GetAllAsync()
        {
            return _mapper.Map<IEnumerable<ContactDto>>(await _context.Contacts
                .AsNoTracking()
                .ToListAsync());
        }
    }
}
