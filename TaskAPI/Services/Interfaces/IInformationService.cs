using TaskAPI.DTOs.Informations;

namespace TaskAPI.Services.Interfaces
{
    public interface IInformationService
    {
        Task CreateAsync(InformationCreateDto data);
        Task EditAsync(int id, InformationEditDto data);
        Task DeleteAsync(int id);
        Task<IEnumerable<InformationDto>> GetAllAsync();
        Task<InformationDetailDto> GetByIdDetailAsync(int id);
        Task<bool> ExistAsync(string title);
        Task<bool> ExistExceptByIdAsync(int id, string title);
    }
}
