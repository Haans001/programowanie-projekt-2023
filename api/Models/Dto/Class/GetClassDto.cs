using api.Models.Dto.Account;

namespace api.Models.Dto.Class;

public class GetClassDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public List<GetAccountDto> UsersDtos { get; set; }
}