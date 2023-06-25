using api.Models.Dto.Class;

namespace api.Services.Interfaces;

public interface IClassService
{
    Task<ICollection<GetClassDto>> GetAllClassesAsync();
    Task<GetClassDto> GetClassByIdAsync(int id);
    Task<int> CreateClassAsync(CreateClassDto createClassDto);
    Task UpdateClassAsync(int id, UpdateClassDto updateClassDto);
    Task DeleteClassAsync(int id);
    Task<ICollection<GetUserClasses>> GetClassesForUserAsync();
} 