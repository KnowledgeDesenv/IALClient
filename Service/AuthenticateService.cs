using IALClient.DTO.Request;
using IALClient.DTO.Response;
using IALClient.Entity;
using IALClient.Service.CustomException;
using Microsoft.AspNetCore.Identity;


namespace IALClient.Service;

public class AuthenticateService(TokenService tokenService, UserManager<ApplicationUser> userManager)
{
    
    public async Task<TokenDto> Authenticate(LoginDto loginDto) 
    {

        var email = loginDto.Email;

        var user = await userManager.FindByEmailAsync(email);

        if (user == null)
        {
            throw new ResourceNotFoundException("The email : " + email + " doesn't exist in the database");
        }

        if(!await userManager.CheckPasswordAsync(user, loginDto.Password)) 
        {

            throw new PasswordIncorrectException();

        }

        var token = tokenService.GenerateToken(user);
        
        return new TokenDto("Bearer", token);
    }

}
