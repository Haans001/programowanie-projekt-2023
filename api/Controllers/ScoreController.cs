using api.Models.Dto.ScoreDto;
using api.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers;

[ApiController]
[Route("api/[controller]")]  
public class ScoreController : ControllerBase
{
    private readonly IScoreService _scoreService;

    public ScoreController(IScoreService scoreService)
    {
        _scoreService = scoreService;
    }
    
    [HttpGet]
    public async Task<ActionResult<List<GetScoreDto>>> ScoresAsync()
    {
        var scores = await _scoreService.ScoresAsync();
        return Ok(scores);
    }
    
    [HttpGet("quiz/{id}")]
    public async Task<ActionResult<List<GetScoreDto>>> ScoresFromQuizAsync(int id)
    {
        var scores = await _scoreService.ScoresFromSpecificQuizAsync(id);
        return Ok(scores);
    }
    
    [HttpGet("{id}")]
    public async Task<ActionResult<GetScoreDto>> GetScoreByIdAsync(int id)
    {
        var score = await _scoreService.GetScoreByIdAsync(id);
        return Ok(score);
    }
    [HttpPost]
    public async Task<ActionResult> CreateScoreAsync(AddScoreDto addScoreDto)
    {
        await _scoreService.CreateScoreAsync(addScoreDto);
        return Ok();
    }
    [HttpDelete("{id}")]
    public async Task<ActionResult> DeleteScoreAsync(int id)
    {
        await _scoreService.DeleteScoreAsync(id);
        return Ok();
    }

}