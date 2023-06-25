using api.DatabaseContext;
using api.Exceptions;
using api.Models.Dto.ScoreDto;
using api.Models.Entities;
using api.Services.Interfaces;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

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
    
    public async Task<List<GetScoreDto>> ScoresAsync()
    {
        var scores = await _context.Scores.ToListAsync();
        return _mapper.Map<List<GetScoreDto>>(scores);
    }

    public async Task<GetScoreDto> GetScoreByIdAsync(int id)
    {
        var score = await _context.Scores.FirstOrDefaultAsync(x => x.Id == id);
        if (score is null)
        {
            throw new NotFoundException("Score not found");
        }
        return _mapper.Map<GetScoreDto>(score);
    }
    
    public async Task CreateScoreAsync(AddScoreDto addScoreDto)
    {
        var score = _mapper.Map<Score>(addScoreDto);
        score.UserId = _userContextService.GetUserId;
        score.DateOfCompletion = DateTime.Now.ToUniversalTime();
        score.QuizId = addScoreDto.QuizId;
        _context.Scores.Add(score);
        _context.SaveChanges();
    }

    public async Task DeleteScoreAsync(int id)
    {
        var score = await _context.Scores.FirstOrDefaultAsync(x => x.Id == id);
        if (score is null)
        {
            throw new NotFoundException("Score not found");
        }
        _context.Scores.Remove(score);
        await _context.SaveChangesAsync();
    }
}