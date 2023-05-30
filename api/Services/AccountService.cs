using api.DatabaseContext;
using api.Models.Dto;
using api.Models.Entities;
using api.Services.Interfaces;

namespace api.Services;

public class AccountService : IAccountService
{ 
    private readonly QuizDbContext _context;
        
    public AccountService(QuizDbContext context)
    {
        _context = context;
    }

    public void RegisterUser(RegisterUserDto registerUserDto)
    {
        var user = new User()
        {
            Email = registerUserDto.Email,
            FirstName = registerUserDto.FirstName,
            LastName = registerUserDto.LastName,
            Password = registerUserDto.Password,
            RoleId = registerUserDto.RoleId
        };
        _context.Users.Add(user);
        _context.SaveChanges();
    }

    public ICollection<Role> GetRoles()
    {
        return _context.Roles.ToList();
    }
}