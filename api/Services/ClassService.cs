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
    
    public ICollection<GetClassDto> GetAllClasses()
    {
        return _mapper.Map<IList<GetClassDto>>(_context.Classes.ToList());
    }

    public GetClassDto GetClassById(int id)
    {
        var existingClass = _context.Classes.Include(u=>u.Users).FirstOrDefault(c => c.Id == id);
        if (existingClass is null)
        {
            throw new NotFoundException("class not found");
        }
        return _mapper.Map<GetClassDto>(existingClass);
    }

    public int CreateClass(CreateClassDto createClassDto)
    {
        var newClass = _mapper.Map<Class>(createClassDto);
        var user = _context.Users.FirstOrDefault(u => u.Id == _userContextService.GetUserId);
        newClass.Users.Add(user);
        newClass.OwnerId = user.Id;
        _context.Classes.Add(newClass);
        _context.SaveChanges();
        return newClass.Id;
    }

    public void UpdateClass(int id, UpdateClassDto updateClassDto)
    {
        var existingClass = _context.Classes.FirstOrDefault(c => c.Id == id);
        if (existingClass is null)
        {
            throw new NotFoundException("class not found");
        }
        _mapper.Map(updateClassDto,existingClass);  
        _context.Classes.Update(existingClass);
        _context.SaveChanges();
    }

    public void DeleteClass(int id)
    {
        var classToDelete = _context.Classes.FirstOrDefault(c => c.Id == id);
        if (classToDelete is null)
        {
            throw new NotFoundException("class not found");
        }
        _context.Classes.Remove(classToDelete);
        _context.SaveChanges();
    }

    public ICollection<GetUserClasses> GetClassesForUser()
    {
        var classes = _context.Classes.Include(c=>c.Users).Where(a=>a.Users.Any(u=>u.Id==_userContextService.GetUserId)).ToList();
        return _mapper.Map<List<GetUserClasses>>(classes);

    }
}