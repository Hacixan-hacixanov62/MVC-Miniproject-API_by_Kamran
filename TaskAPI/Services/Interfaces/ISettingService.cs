using TaskAPI.DTOs.Settings;

namespace TaskAPI.Services.Interfaces
{
    public interface ISettingService
    {
        Task EditAsync(int id, SettingEditDto data);
        Task<Dictionary<string, string>> GetAllAsync();
    }
}
