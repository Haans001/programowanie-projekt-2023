using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using api.DatabaseContext;
using api.Exceptions;
using api.Models.Dto;
using api.Models.Dto.Account;
using api.Models.Entities;
using api.Services.Interfaces;
using AutoMapper;
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
    private readonly IMapper _mapper;
    private readonly IUserContextService _userContextService;
    private readonly AuthenticationSettings _authenicationSettings;

    public AccountService(QuizDbContext context,IPasswordHasher<User> passwordHasher,AuthenticationSettings authenicationSetting,IAuthorizationService authorizationService,IMapper mapper, IUserContextService userContextService)
    {
        _context = context;
        _passwordHasher = passwordHasher;
        _authorizationService = authorizationService;
        _mapper = mapper;
        _userContextService = userContextService;
        this._authenicationSettings = authenicationSetting;
    }

    public GetAccountDto GetAccount()
    {
        var existingUser = _context.Users.Include(u=>u.Role)
            .FirstOrDefault(u=>u.Id==_userContextService.GetUserId);
        if (existingUser is null)
        {
            throw new NotFoundException("user not found");
        }
        return _mapper.Map<GetAccountDto>(existingUser);
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
        var userToUpdate = _context.Users.FirstOrDefault(u => u.Id == id);
        if (userToUpdate is null)
        {
            throw new NotFoundException("user not found");
        }
        _mapper.Map(updateUserDto,userToUpdate);
        _context.SaveChanges();
    }

    public void DeleteUser(int id)
    {
        var existingUser = _context.Users.FirstOrDefault(u => u.Id == id);
        if (existingUser is null)
        {
            throw new NotFoundException("user not found");
        }

        _context.Users.Remove(existingUser);
        _context.SaveChanges();
    }

    public void AddUsertoClass(int classId)
    {
        var user = _context.Users.FirstOrDefault(u=>u.Id==_userContextService.GetUserId);   
            var classs = _context.Classes.FirstOrDefault(c=>c.Id==classId);
            if(user is null || classs is null)
            {
                throw new NotFoundException("user or class not found");
            }
            classs.Users.Add(user);
            _context.SaveChanges();
    }
}