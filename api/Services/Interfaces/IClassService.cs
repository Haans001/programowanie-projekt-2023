using api.Models.Dto.Class;

namespace api.Services.Interfaces;

public interface IClassService
{
    ICollection<GetClassDto> GetAllClasses();
    GetClassDto GetClassById(int id);
    int CreateClass(CreateClassDto createClassDto);
    void UpdateClass(int id, UpdateClassDto updateClassDto);
    void DeleteClass(int id);
}