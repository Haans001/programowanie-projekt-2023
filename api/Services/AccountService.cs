using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using api.DatabaseContext;
using api.Exceptions;
using api.Models.Dto;
using api.Models.Dto.Account;
using api.Models.Dto.Class;
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

    public async Task<GetAccountDto> GetAccountAsync()
    {
        var existingUser = await _context.Users.Include(u=>u.Role)
            .FirstOrDefaultAsync(u=>u.Id==_userContextService.GetUserId);
        if (existingUser is null)
        {
            throw new NotFoundException("użytkownik nie znaleziony");
        }
        return _mapper.Map<GetAccountDto>(existingUser);
    }

    public async Task RegisterUserAsync(RegisterUserDto registerUserDto)
    {
        var user = new User()
        {
            Email = registerUserDto.Email,
            FirstName = registerUserDto.FirstName,
            LastName = registerUserDto.LastName,
            RoleId = registerUserDto.RoleId
        };
        user.Password = _passwordHasher.HashPassword(user,registerUserDto.Password);
        await _context.Users.AddAsync(user);
        await _context.SaveChangesAsync();
    }

    public async Task<ICollection<Role>> GetRolesAsync()
    {
        return await _context.Roles.ToListAsync();
    }

    public object GenerateJwt(LoginDto loginDto)
    {
        var user = _context.Users.Include(u=>u.Role).FirstOrDefault(u => u.Email == loginDto.Email);
        if (user is null)
        {
            throw new BadRequestException("nieprawidłowy email lub hasło");
        }
        var result = _passwordHasher.VerifyHashedPassword(user,user.Password,loginDto.Password);
        if (result == PasswordVerificationResult.Failed)
        {
            throw new BadRequestException("nieprawidłowy email lub hasło");
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

    public async Task UpdateUserAsync(int id, UpdateUserDto updateUserDto)
    {
        var userToUpdate = await _context.Users.FirstOrDefaultAsync(u => u.Id == id);
        if (userToUpdate is null)
        {
            throw new NotFoundException("użytkownik nie znaleziony");
        }
        _mapper.Map(updateUserDto,userToUpdate);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteUserAsync(int id)
    {
        var existingUser = await _context.Users.FirstOrDefaultAsync(u => u.Id == id);
        if (existingUser is null)
        {
            throw new NotFoundException("użytkownik nie znaleziony");
        }

        _context.Users.Remove(existingUser);
        _context.SaveChanges();
    }

    
    //Sprawdzic czy user nie jest juz w klasie lub czy to wgl działa XDDDDDD
    public async Task AddUsertoClassAsync(AddUserToClass addUserToClass)
    {
        var user = await _context.Users.FirstOrDefaultAsync(u=>u.Email==addUserToClass.Email);   
            var classs =await _context.Classes.Include(x=>x.Users).FirstOrDefaultAsync(c=>c.Id==addUserToClass.ClassId);
            if(user is null || classs is null)
            {
                throw new NotFoundException("użytkownik lub klasa nie znaleziona");
            }

            if (classs.Users.Any(u=>u.Email==user.Email))
            {
                throw new BadRequestException("użytkownik jest juz w klasie");
            }
            classs.Users.Add(user);
            await _context.SaveChangesAsync();
    }
}