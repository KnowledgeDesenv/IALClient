using IALClient.DTO.Request;
using IALClient.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace IALClient.Controller;

[Route("authh")]
[ApiController]
public class AuthenticateController(AuthenticateService service) : ControllerBase
{
    
    [AllowAnonymous]
    [HttpPost]
    public async Task<IActionResult> Authenticate([FromBody] LoginDto loginDto)
    {

        var token = await service.Authenticate(loginDto);

        return Ok(token);
    }

}
