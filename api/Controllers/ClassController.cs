using api.Models.Dto.Class;
using api.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers;
[ApiController]
[Route("api/[controller]")]
[Authorize]
public class ClassController : ControllerBase
{
    private readonly IClassService _classService;

    public ClassController(IClassService classService)
    {
        _classService = classService;
    }

    [HttpGet]
    public async Task<ActionResult<IList<GetClassDto>>> GetAllClassesAsync()
    {
        return Ok(await _classService.GetAllClassesAsync());
    }
    
    [HttpGet("{id}")]
    public async Task<ActionResult<GetClassDto>> GetClassAsync([FromRoute] int id)
    {
        return Ok(await _classService.GetClassByIdAsync(id));
    }
    
    [HttpGet("me")]
    public async Task<ActionResult<IEnumerable<GetClassDto>>> GetQuizzesForUserAsync()
    {
        return Ok(await _classService.GetClassesForUserAsync());
    }
    
    
    [HttpPost("create")]
    public async Task<IActionResult> CreateClassAsync([FromBody] CreateClassDto createClassDto)
    {
        var cid = await _classService.CreateClassAsync(createClassDto);
        return Created($"/api/restaurant/{cid}",null);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateClassAsync([FromRoute] int id, [FromBody] UpdateClassDto updateClassDto)
    {
        await _classService.UpdateClassAsync(id,updateClassDto);
        return NoContent();
    }
    
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteClassAsync([FromRoute] int id)
    {
        await _classService.DeleteClassAsync(id);
        return NoContent();
    }
 }