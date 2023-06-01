namespace api.Models.Dto;

public class UpdateQuizDto
{
    public string Name { get; set; }
    public bool isOpen { get; set; }
    public int ClassId { get; set; }
}