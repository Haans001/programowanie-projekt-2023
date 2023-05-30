using api.DatabaseContext;
using api.Models.Dto;
using api.Services.Interfaces;
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
    public IActionResult GetRoles()
    {

        return Ok(_accountService.GetRoles());
    }
    [HttpPost("register")]
    public IActionResult RegisterUser(RegisterUserDto registerUserDto)
    {
        _accountService.RegisterUser(registerUserDto);  
        return Ok();
    }
}