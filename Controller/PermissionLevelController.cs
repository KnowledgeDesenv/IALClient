using IALClient.DTO.Request.register;
using IALClient.DTO.Request.update;
using IALClient.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace IALClient.Controller;

[Route("permission-levels")]
[ApiController]
public class PermissionLevelController(PermissionLevelService service) : ControllerBase
{
    
    [Authorize]
    [HttpGet]
    public async Task<IActionResult> GetAll([FromQuery] int page = 1, [FromQuery] int rows = 10)
    {

        var permissionLevels = await service.GetAll(page, rows);

        return Ok(permissionLevels);
    }


    [Authorize]
    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetById([FromRoute] long id)
    {

        var permissionLevel = await service.GetById(id);

        return Ok(permissionLevel);
    }

    [Authorize]
    [HttpPost]
    public async Task<IActionResult> Save([FromBody] PermissionLevelRegisterDto permissionLevelRegisterDto)
    {

        var permissionLevel = await service.Save(permissionLevelRegisterDto);

        return Created($"/user-vehicles/{permissionLevel.Id}", permissionLevel);
    }

    [Authorize]
    [HttpPut("{id:int}")]
    public async Task<IActionResult> Update([FromBody] PermissionLevelUpdateDto permissionLevelUpdateDto, [FromRoute] long id)
    {

        var permissionLevel = await service.Update(permissionLevelUpdateDto, id);

        return Ok(permissionLevel);
    }

    [Authorize]
    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete([FromRoute] long id)
    {

        await service.Delete(id);

        return NoContent();
    }

}
