using api.DatabaseContext;
using api.Exceptions;
using api.Models.Dto.ScoreDto;
using api.Models.Entities;
using api.Services.Interfaces;
using AutoMapper;

namespace api.Services;

public class ScoreService : IScoreService
{
    private readonly QuizDbContext _context;
    private readonly IMapper _mapper;
    private readonly IUserContextService _userContextService;

    public ScoreService(QuizDbContext context, IMapper mapper, IUserContextService userContextService)
    {
        _context = context;
        _mapper = mapper;
        _userContextService = userContextService;
    }
    
    public List<GetScoreDto> Scores()
    {
        var scores = _context.Scores.ToList();
        return _mapper.Map<List<GetScoreDto>>(scores);
    }

    public GetScoreDto GetScoreById(int id)
    {
        var score = _context.Scores.FirstOrDefault(x => x.Id == id);
        if (score is null)
        {
            throw new NotFoundException("Score not found");
        }
        return _mapper.Map<GetScoreDto>(score);
    }

    public void CreateScore(AddScoreDto addScoreDto)
    {
        var score = _mapper.Map<Score>(addScoreDto);
        score.UserId = _userContextService.GetUserId;
        score.DateOfCompletion = DateTime.Now;
        _context.Scores.Add(score);
        _context.SaveChanges();
    }

    public void DeleteScore(int id)
    {
        var score = _context.Scores.FirstOrDefault(x => x.Id == id);
        if (score is null)
        {
            throw new NotFoundException("Score not found");
        }
        _context.Scores.Remove(score);
        _context.SaveChanges();
    }
}