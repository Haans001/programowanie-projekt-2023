using api.DatabaseContext;
using api.Exceptions;
using api.Models.Dto;
using api.Models.Dto.Class;
using api.Models.Entities;
using api.Services.Interfaces;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

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
    
    public async Task<ICollection<GetQuizDto>> GetAllQuizzesAsync()
    {
        return _mapper.Map<List<GetQuizDto>>(await _context.Quizzes.ToListAsync());    
    }

    public async Task<ICollection<GetQuizDto>> GetAllQuizzesForClassAsync(int id)
    {
        return _mapper.Map<List<GetQuizDto>>(await _context.Quizzes.Where(q=>q.ClassId== id).ToListAsync());  
    }

    public async Task<GetQuizDto> GetQuizByIdAsync(int id)
    {
        var quiz = await _context.Quizzes.FirstOrDefaultAsync(q => q.Id == id);
        if (quiz is null)
        {
            throw new NotFoundException("Quiz not found");
        }
        return _mapper.Map<GetQuizDto>(quiz);   
    }

    public async Task CreateQuizAsync(CreateQuizDto createQuizDto)
    {
        var newQuiz = new Quiz()
        {
            Name = createQuizDto.Name,
            ClassId = createQuizDto.ClassId,
            isOpen = true,
            DateOfCreation = DateTime.UtcNow,
            UserId = _userContextService.GetUserId
        };
        await _context.Quizzes.AddAsync(newQuiz);
        await _context.SaveChangesAsync();
        foreach (var question in createQuizDto.Questions)
        {
            await _questionService.CreateQuestionAsync(question, newQuiz.Id);
        }
    }
    
    public async Task DeleteQuizAsync(int id)
    {
        var quizToDelete = await _context.Quizzes.FirstOrDefaultAsync(q => q.Id == id);
        if (quizToDelete is null)
        {
            throw new NotFoundException("Quiz not found");
        }
        _context.Quizzes.Remove(quizToDelete);
        await _context.SaveChangesAsync();
    }
}