using IALClient.DTO.Request;
using IALClient.Entity;
using IALClient.Service.CustomException;
using Microsoft.AspNetCore.Identity;
namespace IALClient.Service;

public class ChangePasswordService(SendEmailService sendEmailService, UserService userService, UserManager<ApplicationUser> userManager)
{
    
    public async Task SendCodeToEmail(string email)
    {

        var user = await userService.RecoverUserByEmail(email);

        var title = "GWMAPI | Code to recover password";

        var code = GenerateCode();

        var body = BuildMessageSendCode(code);

        sendEmailService.SendEmail(title, body, email);

        user.Code = code;

        await userManager.UpdateAsync(user);
    }


    public async Task Verify(VerifyCodeDto verifyCodeDto)
    {

        var user = await userService.RecoverUserByEmail(verifyCodeDto.Email);

        VerifyCode(user, verifyCodeDto.Code);

    }

    public async Task NewPassword(ChangePasswordDto changePasswordDto)
    {

        var user = await userService.RecoverUserByEmail(changePasswordDto.Email);

        VerifyCode(user, changePasswordDto.Code);

        user.Code = null;

        await userManager.UpdateAsync(user);

        await userManager.RemovePasswordAsync(user);
        await userManager.AddPasswordAsync(user, changePasswordDto.NewPassword);

    }

    private void VerifyCode(ApplicationUser user, string code)
    {
        if (String.IsNullOrEmpty(user.Code) || user.Code != code)
        {
            throw new InvalidChangePasswordCodeException();
        }
    }

    private string BuildMessageSendCode(string code)
    {
        return "Your code is: " + code;

    }

    private string GenerateCode()
    {

        var rand = new Random();

        return rand.Next(10000, 100000).ToString();
    }

}
