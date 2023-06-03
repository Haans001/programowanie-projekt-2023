using api.Models.Dto.Class;
using api.Models.Dto.Role;

namespace api.Models.Dto.Account;

public class GetAccountDto
{
    public int Id { get; set; }
    public string Email { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public GetRoleDto Role { get; set; }
    public int RoleId { get; set; }
}