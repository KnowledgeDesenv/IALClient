using IALClient.DTO.Request;
using IALClient.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace IALClient.Controller;

[Route("change-password")]
[ApiController]
public class ChangePasswordController(ChangePasswordService service) : ControllerBase
{
    
    [AllowAnonymous]
    [HttpGet("code/{email}")]
    public async Task<IActionResult> SendCode([FromRoute] string email)
    {

        await service.SendCodeToEmail(email);

        return Ok();
    }

    [AllowAnonymous]
    [HttpPost("verify-code")]
    public async Task<IActionResult> VerifyCode([FromBody] VerifyCodeDto verifyCodeDTO)
    {

        await service.Verify(verifyCodeDTO);

        return Ok();
    }

    [AllowAnonymous]
    [HttpPost("new-password")]
    public async Task<IActionResult> NewPassword([FromBody] ChangePasswordDto changePasswordDTO)
    {

        await service.NewPassword(changePasswordDTO);

        return Ok();
    }

}
