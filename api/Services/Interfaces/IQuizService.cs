using api.Models.Dto;
using api.Models.Entities;

namespace api.Services.Interfaces;

public interface IQuizService
{
    Task<ICollection<GetQuizDto>> GetAllQuizzesAsync();
    Task<ICollection<GetQuizDto>> GetAllQuizzesForClassAsync(int id);
    Task<GetQuizDto> GetQuizByIdAsync(int id);
    Task CreateQuizAsync(CreateQuizDto createQuizDto);
    Task DeleteQuizAsync(int id);
    Task CloseQuiz(int id);
}