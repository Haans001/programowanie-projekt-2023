using System.Security.Claims;
using api.Models.Dto;
using api.Models.Dto.Question;
using api.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers;

[Route("api/[controller]")]
[ApiController]
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


    [HttpDelete("{id}")]
    public IActionResult DeleteQuiz([FromRoute] int id)
    {
        _quizService.DeleteQuiz(id);
        return NoContent();
    }
    
        
    [HttpPost("{id}/addQuestion")]
    public IActionResult AddQuestion([FromBody]CreateQuestionDto createQuestionDto,[FromRoute] int id)
    {
        _questionService.CreateQuestion(createQuestionDto,id);
        return Ok();
    }

    [HttpGet("{id}/questions")]
    public IActionResult GetQuestions([FromRoute] int id)
    {
        return Ok(_questionService.GetQuestionFromQuiz(id));
    }
    [HttpPut("{id}/questions/{qid}")]
    public IActionResult UpdateQuestion([FromRoute] int id,[FromRoute] int qid,[FromBody] UpdateQuestionDto updateQuestionDto)
    {
        _questionService.UpdateQuestion(id,qid,updateQuestionDto);
        return NoContent();
    }
    [HttpDelete("questions/{qid}")]
    public IActionResult DeleteQuestion([FromRoute] int qid)
    {
        _questionService.DeleteQuestion(qid);
        return NoContent();
    }
}