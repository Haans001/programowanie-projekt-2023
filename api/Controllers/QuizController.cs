using System.Security.Claims;
using api.Models.Dto;
using api.Models.Dto.Class;
using api.Models.Dto.Question;
using api.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers;

[Route("api/[controller]")]
[ApiController]
[Authorize]
public class QuizController : ControllerBase
{
    private readonly IQuizService _quizService;
    private readonly IQuestionService _questionService;

    public QuizController(IQuizService quizService,IQuestionService questionService)
    {
        this._quizService = quizService;
        _questionService = questionService;
    }
    


    [HttpGet] 
    public async Task<IActionResult> GetAllQuizzesAsync()
    {
        return Ok(await _quizService.GetAllQuizzesAsync());
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetQuizByIdAsync([FromRoute] int id)
    {
        return Ok(await _quizService.GetQuizByIdAsync(id));
    }

    [HttpGet("{id}/Class")]
    public async Task<IActionResult> GetQuizForClassAsync([FromRoute] int id)
    {
        return Ok(await _quizService.GetAllQuizzesForClassAsync(id));
    }   
    
    
    [HttpPost("create")]
    [Authorize(Roles = "Teacher")]
    public async Task<IActionResult> CreateQuizAsync([FromBody]CreateQuizDto createQuizDto)
    {
        await _quizService.CreateQuizAsync(createQuizDto);
        return Ok();
    }
    
    [HttpPost("{id}/close")]
    public async Task<IActionResult> CloseQuizAsync([FromRoute]int id)
    {
        await _quizService.CloseQuiz(id);
        return Ok();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteQuizAsync([FromRoute] int id)
    {
        await _quizService.DeleteQuizAsync(id);
        return NoContent();
    }
    
        
    [HttpPost("{id}/addQuestion")]
    public async Task<IActionResult> AddQuestionAsync([FromBody]CreateQuestionDto createQuestionDto,[FromRoute] int id)
    {
        await _questionService.CreateQuestionAsync(createQuestionDto,id);
        return Ok();
    }

    [HttpGet("{id}/questions")]
    public async Task<IActionResult> GetQuestionsAsync([FromRoute] int id)
    {
        return Ok(await _questionService.GetQuestionFromQuizAsync(id));
    }
    [HttpPut("{id}/questions/{qid}")]
    public async Task<IActionResult> UpdateQuestionAsync([FromRoute] int id,[FromRoute] int qid,[FromBody] UpdateQuestionDto updateQuestionDto)
    {
        await _questionService.UpdateQuestionAsync(id,qid,updateQuestionDto);
        return NoContent();
    }
    [HttpDelete("questions/{qid}")]
    public async Task<IActionResult> DeleteQuestionAsync([FromRoute] int qid)
    {
        await _questionService.DeleteQuestionAsync(qid);
        return NoContent();
    }
}