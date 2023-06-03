using api.Models.Dto;
using api.Models.Dto.Account;
using api.Models.Entities;

namespace api.Services.Interfaces;

public interface IAccountService
{
    GetAccountDto GetAccount();
    void RegisterUser(RegisterUserDto registerUserDto);
    ICollection<Role> GetRoles();
    object GenerateJwt(LoginDto loginDto);
    void UpdateUser(int id, UpdateUserDto updateUserDto);
    void DeleteUser(int id);
    void AddUsertoClass(int classId);
}