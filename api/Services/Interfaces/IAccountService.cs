using api.Models.Dto;
using api.Models.Dto.Account;
using api.Models.Dto.Class;
using api.Models.Entities;

namespace api.Services.Interfaces;

public interface IAccountService
{
    Task<GetAccountDto> GetAccountAsync();
    Task RegisterUserAsync(RegisterUserDto registerUserDto);
    Task<ICollection<Role>> GetRolesAsync();
    object GenerateJwt(LoginDto loginDto);
    Task UpdateUserAsync(int id, UpdateUserDto updateUserDto);
    Task DeleteUserAsync(int id);
    Task AddUsertoClassAsync(AddUserToClass addUserToClass);
}