using api.DatabaseContext;
using api.Exceptions;
using api.Models.Dto.Class;
using api.Models.Entities;
using api.Services.Interfaces;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace api.Services;

public class ClassService : IClassService
{
    private readonly QuizDbContext _context;
    private readonly IMapper _mapper;
    private readonly AuthenticationSettings _authenicationSettings;
    private readonly IUserContextService _userContextService;
    public ClassService(QuizDbContext context,IMapper mapper, AuthenticationSettings authenicationSettings, IUserContextService userContextService)
    {
        _context = context;
        _mapper = mapper;
        _authenicationSettings = authenicationSettings;
        _userContextService = userContextService;
    }
    
    public async Task<ICollection<GetClassDto>> GetAllClassesAsync()
    {
        return _mapper.Map<IList<GetClassDto>>(await _context.Classes.ToListAsync());
    }

    public async Task<GetClassDto> GetClassByIdAsync(int id)
    {
        var existingClass = await _context.Classes.Include(u=>u.Users).FirstOrDefaultAsync(c => c.Id == id);
        if (existingClass is null)
        {
            throw new NotFoundException("class not found");
        }
        return _mapper.Map<GetClassDto>(existingClass);
    }

    public async Task<int> CreateClassAsync(CreateClassDto createClassDto)
    {
        var newClass = _mapper.Map<Class>(createClassDto);
        var user = await _context.Users.FirstOrDefaultAsync(u => u.Id == _userContextService.GetUserId);
        newClass.Users.Add(user);
        newClass.OwnerId = user.Id;
        await _context.Classes.AddAsync(newClass);
        await _context.SaveChangesAsync();
        return newClass.Id;
    }

    public async Task UpdateClassAsync(int id, UpdateClassDto updateClassDto)
    {
        var existingClass = await _context.Classes.FirstOrDefaultAsync(c => c.Id == id);
        if (existingClass is null)
        {
            throw new NotFoundException("class not found");
        }
        _mapper.Map(updateClassDto,existingClass);  
        _context.Classes.Update(existingClass);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteClassAsync(int id)
    {
        var classToDelete = await _context.Classes.FirstOrDefaultAsync(c => c.Id == id);
        if (classToDelete is null)
        {
            throw new NotFoundException("class not found");
        }
        _context.Classes.Remove(classToDelete); 
        await _context.SaveChangesAsync();
    }

    public async Task<ICollection<GetUserClasses>> GetClassesForUserAsync()
    {
        var classes = await _context.Classes.Include(c=>c.Users).Where(a=>a.Users.Any(u=>u.Id==_userContextService.GetUserId)).ToListAsync();
        return _mapper.Map<List<GetUserClasses>>(classes);

    }
}