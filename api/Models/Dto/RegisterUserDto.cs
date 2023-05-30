using System.ComponentModel.DataAnnotations;

namespace api.Models.Dto;

public class RegisterUserDto
{
    [Required]
    public string FirstName { get; set; }
    public string LastName { get; set; }

    public string Password { get; set; }
    [Required]
    [MinLength(6)]
    public string Email { get; set; }
    public int RoleId { get; set; } = 2;
}