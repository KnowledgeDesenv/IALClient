using IALClient.Entity;

namespace IALClient.DTO.Response;

public class UserWithUserVehicleResponseDto
{

    public string UserId { get; }

    public string Email { get; }

    public string Name { get; }

    public long UserVehicleId { get; }

    public string Vin { get; }

    public string Key { get; }

    public long? PermissionLevelId { get; }

    public long UserVehicleStatusId { get; }

    public bool Favorite { get; }

    public UserWithUserVehicleResponseDto(ApplicationUser user, UserVehicle userVehicle)
    {
        UserId = user.Id;
        Email = user.Email!;
        Name = user.Name;
        UserVehicleId = userVehicle.Id;
        Vin = userVehicle.Vin;
        Key = userVehicle.Key;
        PermissionLevelId = userVehicle.PermissionLevelId;
        UserVehicleStatusId = userVehicle.UserVehicleStatusId;
        Favorite = userVehicle.Favorite;
    }

}
