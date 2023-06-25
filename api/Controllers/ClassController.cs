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
    public async Task<ActionResult<IList<GetClassDto>>> GetAllClasses()
    {
        return Ok(await _classService.GetAllClassesAsync());
    }
    
    [HttpGet("{id}")]
    public async Task<ActionResult<GetClassDto>> GetClass([FromRoute] int id)
    {
        return Ok(await _classService.GetClassByIdAsync(id));
    }
    
    [HttpGet("me")]
    public async Task<ActionResult<IEnumerable<GetClassDto>>> GetQuizzesForUser()
    {
        return Ok(await _classService.GetClassesForUserAsync());
    }
    
    
    [HttpPost("create")]
    public async Task<IActionResult> CreateClass([FromBody] CreateClassDto createClassDto)
    {
        var cid = await _classService.CreateClassAsync(createClassDto);
        return Created($"/api/restaurant/{cid}",null);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateClass([FromRoute] int id, [FromBody] UpdateClassDto updateClassDto)
    {
        await _classService.UpdateClassAsync(id,updateClassDto);
        return NoContent();
    }
    
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteClass([FromRoute] int id)
    {
        await _classService.DeleteClassAsync(id);
        return NoContent();
    }
 }