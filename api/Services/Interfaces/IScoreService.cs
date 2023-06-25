using api.Models.Dto.ScoreDto;

namespace api.Services.Interfaces;

public interface IScoreService
{
    Task<List<GetScoreDto>> ScoresAsync();
    Task<GetScoreDto> GetScoreByIdAsync(int id);
    Task CreateScoreAsync(AddScoreDto addScoreDto);
    Task DeleteScoreAsync(int id);
}