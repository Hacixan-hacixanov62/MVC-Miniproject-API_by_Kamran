using TaskAPI.DTOs.Contacts;

namespace TaskAPI.Services.Interfaces
{
    public interface IContactService
    {
        Task CreateAsync(ContactCreateDto data);
        Task DeleteAsync(int id);
        Task<IEnumerable<ContactDto>> GetAllAsync();
    }
}
