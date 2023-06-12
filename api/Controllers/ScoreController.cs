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
    public ActionResult<List<GetScoreDto>> Scores()
    {
        var scores = _scoreService.Scores();
        return Ok(scores);
    }
    [HttpGet("{id}")]
    public ActionResult<GetScoreDto> GetScoreById(int id)
    {
        var score = _scoreService.GetScoreById(id);
        return Ok(score);
    }
    [HttpPost]
    public ActionResult CreateScore(AddScoreDto addScoreDto)
    {
        _scoreService.CreateScore(addScoreDto);
        return Ok();
    }
    [HttpDelete("{id}")]
    public ActionResult DeleteScore(int id)
    {
        _scoreService.DeleteScore(id);
        return Ok();
    }

}