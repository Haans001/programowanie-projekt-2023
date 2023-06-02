using System.Security.Claims;
using api.Models.Dto;
using api.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class QuizController : ControllerBase
{
    private readonly IQuizService _quizService;

    public QuizController(IQuizService quizService)
    {
        this._quizService = quizService;
    }
    
    [HttpGet] 
    public IActionResult GetAllQuizzes()
    {
        return Ok(_quizService.GetAllQuizzes());
    }

    [HttpGet("{id}")]
    public IActionResult GetQuizById([FromRoute] int id)
    {
        return Ok(_quizService.GetQuizById(id));
    }

    [HttpGet("{id}/Class")]
    public IActionResult GetQuizForClass([FromRoute] int id)
    {
        return Ok(_quizService.GetAllQuizzesForClass(id));
    }   
    
    
    [HttpPost("create")]
    [Authorize(Roles = "Teacher")]
    public IActionResult CreateQuiz([FromBody]CreateQuizDto createQuizDto)
    {
        _quizService.CreateQuiz(createQuizDto);
        return Ok();
    }


    [HttpDelete("id")]
    public IActionResult DeleteQuiz([FromRoute] int id)
    {
        _quizService.DeleteQuiz(id);
        return NoContent();
    }
}