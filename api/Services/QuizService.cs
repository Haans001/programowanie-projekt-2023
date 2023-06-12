using api.DatabaseContext;
using api.Exceptions;
using api.Models.Dto;
using api.Models.Dto.Class;
using api.Models.Entities;
using api.Services.Interfaces;
using AutoMapper;

namespace api.Services;

public class QuizService : IQuizService
{
    private readonly QuizDbContext _context;
    private readonly IUserContextService _userContextService;
    private readonly IMapper _mapper;
    private readonly IQuestionService _questionService;

    public QuizService(QuizDbContext context,IUserContextService userContextService,IMapper mapper,IQuestionService questionService)
    {
        _context = context;
        _userContextService = userContextService;
        _mapper = mapper;
        _questionService = questionService;
    }
    
    public ICollection<GetQuizDto> GetAllQuizzes()
    {
        return _mapper.Map<List<GetQuizDto>>(_context.Quizzes.ToList());    
    }

    public ICollection<GetQuizDto> GetAllQuizzesForClass(int id)
    {
        return _mapper.Map<List<GetQuizDto>>(_context.Quizzes.Where(q=>q.ClassId== id).ToList());  
    }

    public GetQuizDto GetQuizById(int id)
    {
        var quiz = _context.Quizzes.FirstOrDefault(q => q.Id == id);
        if (quiz is null)
        {
            throw new NotFoundException("Quiz not found");
        }
        return _mapper.Map<GetQuizDto>(quiz);   
    }

    public void CreateQuiz(CreateQuizDto createQuizDto)
    {
        var newQuiz = new Quiz()
        {
            Name = createQuizDto.Name,
            ClassId = createQuizDto.ClassId,
            isOpen = true,
            DateOfCreation = DateTime.UtcNow,
            UserId = _userContextService.GetUserId
        };
        _context.Quizzes.Add(newQuiz);
        _context.SaveChanges();
        foreach (var question in createQuizDto.Questions)
        {
            _questionService.CreateQuestion(question, newQuiz.Id);
        }
    }
    
    public void DeleteQuiz(int id)
    {
        var quizToDelete = _context.Quizzes.FirstOrDefault(q => q.Id == id);
        if (quizToDelete is null)
        {
            throw new NotFoundException("Quiz not found");
        }
        _context.Quizzes.Remove(quizToDelete);
        _context.SaveChanges();
    }
}