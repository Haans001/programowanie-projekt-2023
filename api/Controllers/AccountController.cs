using System.Security.Claims;
using api.DatabaseContext;
using api.Models.Dto;
using api.Models.Dto.Account;
using api.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers;
[Route("api/[controller]")]
[ApiController]
public class AccountController : ControllerBase
{
    private readonly QuizDbContext _context;
    private readonly IAccountService _accountService;

    public AccountController(QuizDbContext context, IAccountService accountService)
    {
        _context = context;
        _accountService = accountService;
    }
    [HttpGet("roles")]
    [Authorize]
    public IActionResult GetRoles()
    {

        return Ok(_accountService.GetRoles());
    }
    [HttpPost("register")]
    [Authorize]
    public IActionResult RegisterUser(RegisterUserDto registerUserDto)
    {
        var userid = User.FindFirst(ClaimTypes.NameIdentifier).Value;
        _accountService.RegisterUser(registerUserDto);  
        return Ok(userid);
    }
    [HttpPost("login")]
    public IActionResult Login([FromBody] LoginDto loginDto)
    {
        var token = _accountService.GenerateJwt(loginDto);
        return Ok(token );
    }
}