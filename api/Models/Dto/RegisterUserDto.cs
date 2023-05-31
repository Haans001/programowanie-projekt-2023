using System.ComponentModel.DataAnnotations;

namespace api.Models.Dto;

public class RegisterUserDto
{
    public string FirstName { get; set; }
    public string LastName { get; set; }

    public string Password { get; set; }
    public string ConfirmPassword { get; set; }
    public string Email { get; set; }
    public int RoleId { get; set; } = 2;
}