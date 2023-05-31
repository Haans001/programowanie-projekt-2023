using api.Models.Dto;
using api.Models.Entities;

namespace api.Services.Interfaces;

public interface IAccountService
{
    void RegisterUser(RegisterUserDto registerUserDto);
    ICollection<Role> GetRoles();
    object GenerateJwt(LoginDto loginDto);
}