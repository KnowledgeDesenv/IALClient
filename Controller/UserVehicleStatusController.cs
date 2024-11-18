using IALClient.DTO.Request.register;
using IALClient.DTO.Request.update;
using IALClient.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace IALClient.Controller;

[Route("user-vehicle-status")]
[ApiController]
public class UserVehicleStatusController(UserVehicleStatusService service) : ControllerBase
{
    
    [Authorize]
    [HttpGet]
    public async Task<IActionResult> GetAll([FromQuery] int page = 1, [FromQuery] int rows = 10)
    {

        var userVehicleStatusList = await service.GetAll(page, rows);

        return Ok(userVehicleStatusList);
    }


    [Authorize]
    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetById([FromRoute] long id)
    {
        
        var userVehicleStatus = await service.GetById(id);

        return Ok(userVehicleStatus);
    }

    [Authorize]
    [HttpPost]
    public async Task<IActionResult> Save([FromBody] UserVehicleStatusRegisterDto userVehicleStatusRegisterDto)
    {

        var userVehicleStatus =  await service.Save(userVehicleStatusRegisterDto);

        return Created($"/user-vehicles/{userVehicleStatus.Id}", userVehicleStatus);
    }

    [Authorize]
    [HttpPut("{id:int}")]
    public async Task<IActionResult> Update([FromBody] UserVehicleStatusUpdateDto userVehicleStatusUpdateDto, [FromRoute] long id)
    {

        var userVehicleStatus = await service.Update(userVehicleStatusUpdateDto, id);

        return Ok(userVehicleStatus);
    }

    [Authorize]
    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete([FromRoute] long id)
    {

        await service.Delete(id);

        return NoContent();
    }

}
