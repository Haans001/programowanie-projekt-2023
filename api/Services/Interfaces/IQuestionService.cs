using api.Models.Dto.Question;

namespace api.Services.Interfaces;

public interface IQuestionService
{
    Task<List<GetQuestionDto>> GetQuestionFromQuizAsync(int id);
    Task<GetQuestionDto> GetQuestionByIdAsync(int id);
    Task CreateQuestionAsync(CreateQuestionDto createQuestionDto,int quizId);
    Task UpdateQuestionAsync(int id,int qid, UpdateQuestionDto updateQuestionDto);
    Task DeleteQuestionAsync(int id);
}