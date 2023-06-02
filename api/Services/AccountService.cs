using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using api.DatabaseContext;
using api.Exceptions;
using api.Models.Dto;
using api.Models.Dto.Account;
using api.Models.Entities;
using api.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace api.Services;

public class AccountService : IAccountService
{ 
    private readonly QuizDbContext _context;
    private readonly IPasswordHasher<User> _passwordHasher;
    private readonly IAuthorizationService _authorizationService;
    private readonly AuthenticationSettings _authenicationSettings;

    public AccountService(QuizDbContext context,IPasswordHasher<User> passwordHasher,AuthenticationSettings authenicationSetting,IAuthorizationService authorizationService)
    {
        _context = context;
        _passwordHasher = passwordHasher;
        _authorizationService = authorizationService;
        this._authenicationSettings = authenicationSetting;
    }

    public void RegisterUser(RegisterUserDto registerUserDto)
    {
        var user = new User()
        {
            Email = registerUserDto.Email,
            FirstName = registerUserDto.FirstName,
            LastName = registerUserDto.LastName,
            RoleId = registerUserDto.RoleId
        };
        user.Password = _passwordHasher.HashPassword(user,registerUserDto.Password);
        _context.Users.Add(user);
        _context.SaveChanges();
    }

    public ICollection<Role> GetRoles()
    {
        return _context.Roles.ToList();
    }

    public object GenerateJwt(LoginDto loginDto)
    {
        var user = _context.Users.Include(u=>u.Role).FirstOrDefault(u => u.Email == loginDto.Email);
        if (user is null)
        {
            throw new BadRequestException("Invalid email or password");
        }
        var result = _passwordHasher.VerifyHashedPassword(user,user.Password,loginDto.Password);
        if (result == PasswordVerificationResult.Failed)
        {
            throw new BadRequestException("Invalid email or password");
        }

        var claims = new List<Claim>()
        {
            new Claim(ClaimTypes.NameIdentifier,user.Id.ToString()),
            new Claim(ClaimTypes.Name,$"{user.FirstName} {user.LastName}"),
            new Claim(ClaimTypes.Role,user.Role.Name)
        };
        
        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_authenicationSettings.JwtKey));
        var creds = new SigningCredentials(key,SecurityAlgorithms.HmacSha256);
        var expires = DateTime.Now.AddDays(_authenicationSettings.JwtExpireDays);
        
        var token = new JwtSecurityToken(_authenicationSettings.JwtIssuer,
            _authenicationSettings.JwtIssuer,
            claims,
            expires: expires,
            signingCredentials: creds);
        var tokenHandler = new JwtSecurityTokenHandler();
        return tokenHandler.WriteToken(token);
    }

    public void UpdateUser(int id, UpdateUserDto updateUserDto)
    {
        throw new NotImplementedException();
    }

    public void DeleteUser(int id)
    {
        throw new NotImplementedException();
    }
}