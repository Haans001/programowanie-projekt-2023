using api.Models.Dto.Class;
using api.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers;
[ApiController]
[Route("api/[controller]")]
public class ClassController : ControllerBase
{
    private readonly IClassService _classService;

    public ClassController(IClassService classService)
    {
        _classService = classService;
    }

    [HttpGet]
    public ActionResult<IList<GetClassDto>> GetAllClasses()
    {
        return Ok(_classService.GetAllClasses());
    }
    
    [HttpGet("{id}")]
    public ActionResult<GetClassDto> GetClass([FromRoute] int id)
    {
        return Ok(_classService.GetClassById(id));
    }

    
    
    [HttpPost("create")]
    public IActionResult CreateClass([FromBody] CreateClassDto createClassDto)
    {
        var cid = _classService.CreateClass(createClassDto);
        return Created($"/api/restaurant/{cid}",null);
    }

    [HttpPut("{id}")]
    public IActionResult UpdateClass([FromRoute] int id, [FromBody] UpdateClassDto updateClassDto)
    {
        _classService.UpdateClass(id,updateClassDto);
        return NoContent();
    }
    
    [HttpDelete("{id}")]
    public IActionResult DeleteClass([FromRoute] int id)
    {
        _classService.DeleteClass(id);
        return NoContent();
    }
 }