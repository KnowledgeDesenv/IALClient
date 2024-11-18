using IALClient.DTO.Request.register;
using IALClient.DTO.Request.update;
using IALClient.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;


namespace IALClient.Controller;

[Route("users")]
[ApiController]
public class UserController(UserService service) : ControllerBase
{
    
    [Authorize]
    [HttpGet]
    public async Task<IActionResult> GetAll([FromQuery] int page = 1, [FromQuery] int rows = 10)
    {

        var users = await service.GetAll(page, rows);

        return Ok(users);
    }

    [Authorize]
    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] string id)
    {
        
        var user = await service.GetById(id);

        return Ok(user);
    }

    [Authorize]
    [HttpPost]
    public async Task<IActionResult> Save([FromBody] UserRegisterDto userRegisterDto)
    {

        var userLoggedId = User.FindFirstValue(ClaimTypes.NameIdentifier)!;

        var user = await service.Save(userRegisterDto, userLoggedId);

        return Created($"/users/{user.Id}", user);
    }

    [AllowAnonymous]
    [HttpPost("with-user-vehicle")]
    public async Task<IActionResult> SaveWithUserVehicle([FromBody] UserWithUserVehicleRegisterDto registerDto)
    {

        var user = await service.SaveWithUserVehicle(registerDto);

        return Created($"/users/{user.UserId}", user);
    }

    [Authorize]
    [HttpPut("change-password")]
    public async Task<IActionResult> ChangePasswordUserLogged([FromBody] ChangePasswordUserLoggedDto wrapper)
    {
        
        var userLoggedId = User.FindFirstValue(ClaimTypes.NameIdentifier)!;

        await service.ChangePasswordUserLogged(wrapper, userLoggedId);

        return Ok();
    }
    

}
