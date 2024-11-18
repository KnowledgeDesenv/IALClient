using IALClient.Entity;

namespace IALClient.DTO.Response;

public class UserResponseDto
{

    public string Id { get; }

    public string Email { get; }

    public string Name { get; }

    public UserResponseDto(ApplicationUser user)
    {
        Id = user.Id;
        Email = user.Email!;
        Name = user.Name;
    }

    public UserResponseDto(string id, string email, string name)
    {
        Id = id;
        Email = email;
        Name = name;
    }


}
