using api.DatabaseContext;
using api.Exceptions;
using api.Models.Dto.Question;
using api.Models.Entities;
using api.Services.Interfaces;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace api.Services;

public class QuestionService : IQuestionService
{
    private readonly QuizDbContext _context;    
    private readonly IUserContextService _userContextService;
    private readonly IMapper _mapper;

    public QuestionService(QuizDbContext context, IUserContextService userContextService,IMapper mapper)
    {
        _context = context;
        _userContextService = userContextService;
        _mapper = mapper;
    }


    public async Task<List<GetQuestionDto>> GetQuestionFromQuizAsync(int id)
    { 
        var quiz = await _context.Quizzes.FirstOrDefaultAsync(q => q.Id == id);
        if (quiz is null)
        {
            throw new NotFoundException("Quiz not found");
        }
        var questions = await _context.Questions.Include(q=>q.Answers).Where(q => q.QuizId == id).ToListAsync();
        if (questions is null || questions.Count == 0)
        {
            throw new NotFoundException("Quiz is empty");
        }
        return _mapper.Map<List<GetQuestionDto>>(questions);
    }

    public async Task<GetQuestionDto> GetQuestionByIdAsync(int id)
    {
        return _mapper.Map<GetQuestionDto>(await _context.Questions.Include(q=>q.Answers).FirstOrDefaultAsync(q => q.Id == id));
    }

    public async Task CreateQuestionAsync(CreateQuestionDto createQuestionDto,int quizId)
    {
        var result = new Question()
        {
            Contents = createQuestionDto.Content,
            QuizId = quizId
        }; 
        result.Answers.Add(new Answer(){Content = createQuestionDto.Answer1,IsCorrect = createQuestionDto.IsCorrect1});
        result.Answers.Add(new Answer(){Content = createQuestionDto.Answer2,IsCorrect = createQuestionDto.IsCorrect2});
        result.Answers.Add(new Answer(){Content = createQuestionDto.Answer3,IsCorrect = createQuestionDto.IsCorrect3});
        result.Answers.Add(new Answer(){Content = createQuestionDto.Answer3,IsCorrect = createQuestionDto.IsCorrect4});
        await _context.Questions.AddAsync(result);
        await _context.SaveChangesAsync();
    }
    
    public async Task UpdateQuestionAsync(int id,int qid, UpdateQuestionDto updateQuestionDto)
    {

       var questionToUpdate = await _context.Questions.Include(a=>a.Answers).FirstOrDefaultAsync(q => q.Id == id);
         if (questionToUpdate is null)
         {
              throw new NotFoundException("Question not found");
         } 
         questionToUpdate.Contents = updateQuestionDto.Content;
         questionToUpdate.Answers.Clear();
         List<Answer> answers = new();
         answers.Add(new Answer(){Content = updateQuestionDto.Answer1,IsCorrect = updateQuestionDto.IsCorrect1});
         answers.Add(new Answer(){Content = updateQuestionDto.Answer2,IsCorrect = updateQuestionDto.IsCorrect2}); 
         answers.Add(new Answer(){Content = updateQuestionDto.Answer3,IsCorrect = updateQuestionDto.IsCorrect3});
         answers.Add(new Answer(){Content = updateQuestionDto.Answer3,IsCorrect = updateQuestionDto.IsCorrect4});
         questionToUpdate.Answers = answers;
         _context.Questions.Update(questionToUpdate);
         await _context.SaveChangesAsync();
    }
    

    public async Task DeleteQuestionAsync(int id)
    {
        var questionToDelete = await _context.Questions.FirstOrDefaultAsync(q => q.Id == id);
        if (questionToDelete is null)
        {
            throw new NotFoundException("Question not found");
        }
        _context.Questions.Remove(questionToDelete);
        await _context.SaveChangesAsync();
    }
}