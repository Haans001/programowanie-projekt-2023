
namespace api.Models.Entities;

public class User
{
     public int Id { get; set; }
     public string Email { get; set; }
     public string FirstName { get; set; }
     public string LastName { get; set; }
     public string Password { get; set; }
     public virtual Role Role { get; set; }
     public int RoleId { get; set; }
     public virtual ICollection<Score> Scores { get; set; }
     public virtual ICollection<Quiz> Quizzes { get; set; }
     public virtual ICollection<Class> Classes { get; set; }
}