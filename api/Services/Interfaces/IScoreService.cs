using api.Models.Dto.ScoreDto;

namespace api.Services.Interfaces;

public interface IScoreService
{
    List<GetScoreDto> Scores();
    GetScoreDto GetScoreById(int id);
    void CreateScore(AddScoreDto addScoreDto);
    void DeleteScore(int id);
}