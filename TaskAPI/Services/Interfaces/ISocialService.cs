using TaskAPI.DTOs.Socials;

namespace TaskAPI.Services.Interfaces
{
    public interface ISocialService
    {
        Task CreateAsync(SocialCreateDto data);
        Task EditAsync(int id, SocialEditDto data);
        Task DeleteAsync(int id);
        Task<IEnumerable<SocialDto>> GetAllAsync();
        Task<bool> ExistAsync(string name);
        Task<bool> ExistExceptByIdAsync(int id, string name);
    }
}
