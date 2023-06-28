using api.Models.Dto.ScoreDto;

namespace api.Services.Interfaces;

public interface IScoreService
{
    Task<List<GetScoreDto>> ScoresAsync();
    Task<List<GetScoreDto>> ScoresFromSpecificQuizAsync(int id);
    Task<GetScoreDto> GetScoreByIdAsync(int id);
    Task CreateScoreAsync(AddScoreDto addScoreDto);
    Task DeleteScoreAsync(int id);
}