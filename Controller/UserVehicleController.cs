using IALClient.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using IALClient.DTO.Request.register;
using IALClient.DTO.Request.update;

namespace IALClient.Controller;

[Route("user-vehicles")]
[ApiController]
public class UserVehicleController(UserVehicleService service) : ControllerBase
{
    
    [Authorize]
    [HttpGet]
    public async Task<IActionResult> GetAll([FromQuery] int page = 1, [FromQuery] int rows = 10)
    {

        var userVehicles = await service.GetAll(page, rows);

        return Ok(userVehicles);
    }

    [Authorize]
    [HttpGet("user/{id}")]
    public async Task<IActionResult> GetByUserId([FromRoute] string id)
    {

        var userVehicles = await service.GetByUserId(id);

        return Ok(userVehicles);
    }

    [Authorize]
    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetById([FromRoute] long id)
    {
        
        var userVehicle = await service.GetById(id);

        return Ok(userVehicle);
    }

    [Authorize]
    [HttpPost]
    public async Task<IActionResult> Save([FromBody] UserVehicleRegisterDto userVehicleRegisterDto)
    {

        var userId = User.FindFirstValue(ClaimTypes.NameIdentifier)!;

        var userVehicle = await service.Save(userVehicleRegisterDto, userId);

        return Created($"/user-vehicles/{userVehicle.Id}", userVehicle);
    }

    [Authorize]
    [HttpPut("{id:int}")]
    public async Task<IActionResult> Update([FromBody] UserVehicleUpdateDto userVehicleUpdateDto, [FromRoute] long id)
    {

        var userId = User.FindFirstValue(ClaimTypes.NameIdentifier)!;

        var userVehicle = await service.Update(userVehicleUpdateDto, id, userId);

        return Ok(userVehicle);
    }

    [Authorize]
    [HttpPut("favorite/{id:int}")]
    public async Task<IActionResult> UpdateAsFavorite([FromRoute] long id)
    {

        var userId = User.FindFirstValue(ClaimTypes.NameIdentifier)!;

        await service.UpdateAsFavorite(id, userId);

        return NoContent();
    }

    [Authorize]
    [HttpPut("submit-document/{id:int}")]
    public async Task<IActionResult> SubmitDocument([FromForm] ICollection<IFormFile> image, [FromRoute] long id)
    {

        var userLoggedId = User.FindFirstValue(ClaimTypes.NameIdentifier)!;

        var userVehicle = await service.SubmitDocument(image, id, userLoggedId);

        return Ok(userVehicle);
    }

    [Authorize]
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute] long id)
    {

        var userLoggedId = User.FindFirstValue(ClaimTypes.NameIdentifier)!;

        await service.Delete(id, userLoggedId);

        return NoContent();
    }


}
