using IALClient.DTO.Request.register;
using IALClient.DTO.Response;
using IALClient.Entity;
using IALClient.Entity.Projection;
using Microsoft.AspNetCore.Identity;


namespace IALClient.Mapper;

public class UserMapper
{

    public static ApplicationUser ToEntity(UserRegisterDto userDto)
    {
        return new ApplicationUser(userDto.Email, userDto.Name);
    }

    public static UserResponseDto ToDto(ApplicationUser user)
    {
        return new UserResponseDto(user);
    }

    public static UserResponseDto ToDto(string id, string email, string name)
    {
        return new UserResponseDto(id, email, name);
    }

    public static List<UserResponseDto> ToDtoList(List<UserProjection> users)
    {
        return users.Select(p => new UserResponseDto(p.Id, p.Email, p.Name)).ToList();
    }

    public static List<UserResponseDto> ToDtoList(List<ApplicationUser> users)
    {
        return users.Select(ToDto).ToList();
    }

}
