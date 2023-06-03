using api.Models.Dto.Question;

namespace api.Services.Interfaces;

public interface IQuestionService
{
    List<GetQuestionDto> GetQuestionFromQuiz(int id);
    GetQuestionDto GetQuestionById(int id);
    void CreateQuestion(CreateQuestionDto createQuestionDto,int quizId);
    void UpdateQuestion(int id,int qid, UpdateQuestionDto updateQuestionDto);
    void DeleteQuestion(int id);
}