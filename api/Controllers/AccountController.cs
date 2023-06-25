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
    private readonly IAccountService _accountService;

    public AccountController(IAccountService accountService)
    {
        _accountService = accountService;
    }
    
    [HttpGet("me")]
    [Authorize]
    public async Task<IActionResult> MeAsync()
    {
        return Ok( await _accountService.GetAccountAsync());
    }
        
    
    [HttpGet("roles")]
    public async Task<IActionResult> GetRolesAsync()
    {   

        return Ok(await _accountService.GetRolesAsync());
    }
    
    [HttpPost("register")]
    public async Task<IActionResult> RegisterUserAsync(RegisterUserDto registerUserDto)
    {
        await _accountService.RegisterUserAsync(registerUserDto);  
        return Ok();
    }
    
    [HttpPost("Class/{classid}")]
    public async Task<IActionResult> AddUsertoClassAsync([FromRoute] int classid)
    {
        await _accountService.AddUsertoClassAsync(classid);  
        return Ok();
    }
    
    [HttpPost("login")]
    public IActionResult Login([FromBody] LoginDto loginDto)
    {
        var token = _accountService.GenerateJwt(loginDto);
        return Ok(token);
    }
}