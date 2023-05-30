namespace api.Models.Entities;

public class Quiz
{
    public int Id { get; set; }   
    public string Name { get; set; }
    public DateTime DateOfCreation { get; set; }
    public bool isOpen { get; set; }
    public ICollection<Question> Questions { get; set; }
    public User User { get; set; }
    public int UserId { get; set; }
    public virtual ICollection<Score> Scores { get; set; }

    public virtual ICollection<Class> Classes { get; set; }
    public int ClassId { get; set; }
}