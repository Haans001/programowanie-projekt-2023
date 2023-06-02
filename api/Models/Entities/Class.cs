namespace api.Models.Entities;

public class Class
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public virtual ICollection<Quiz> Quizzes { get; set; } = new List<Quiz>();
    public virtual ICollection<User> Users { get; set; } = new List<User>();
}    