using IALClient.DTO.Request.register;
using IALClient.DTO.Request.update;
using IALClient.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace IALClient.Controller;

[Route("configs")]
[ApiController]
public class ConfigController(ConfigService service) : ControllerBase
{
    
    [Authorize]
    [HttpGet]
    public async Task<IActionResult> GetAll([FromQuery] int page = 1, [FromQuery] int rows = 10)
    {

        var configs = await service.GetAll(page, rows);

        return Ok(configs);
    }


    [Authorize]
    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetById([FromRoute] long id)
    {
        var config = await service.GetById(id);

        return Ok(config);
    }

    [Authorize]
    [HttpPost]
    public async Task<IActionResult> Save([FromBody] ConfigRegisterDto configRegisterDto)
    {

        var userId = User.FindFirstValue(ClaimTypes.NameIdentifier)!;

        var config = await service.Save(configRegisterDto, userId);

        return Created($"/configs/{config.Id}", config);
    }

    [Authorize]
    [HttpPut("{id:int}")]
    public async Task<IActionResult> Update([FromBody] ConfigUpdateDto configUpdateDto, [FromRoute] long id)
    {

        var userId = User.FindFirstValue(ClaimTypes.NameIdentifier)!;

        var config = await service.Update(configUpdateDto, id, userId);

        return Ok(config);
    }

    [Authorize]
    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete([FromRoute] long id)
    {

        await service.Delete(id);

        return NoContent();
    }

}
