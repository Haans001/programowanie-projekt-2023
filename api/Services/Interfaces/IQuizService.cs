using api.Models.Dto;
using api.Models.Entities;

namespace api.Services.Interfaces;

public interface IQuizService
{
    ICollection<GetQuizDto> GetAllQuizzes();
    ICollection<GetQuizDto> GetAllQuizzesForClass(int id);
    GetQuizDto GetQuizById(int id);
    void CreateQuiz(CreateQuizDto createQuizDto);
    void UpdateQuiz(int id, UpdateQuizDto updateQuizDto);
    void DeleteQuiz(int id);
}