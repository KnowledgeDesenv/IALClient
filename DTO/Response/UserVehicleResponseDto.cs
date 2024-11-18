using IALClient.Entity;

namespace IALClient.DTO.Response;

public class UserVehicleResponseDto(UserVehicle userVehicle)
{

    public long Id { get; } = userVehicle.Id;

    public string Vin { get; } = userVehicle.Vin;

    public string Key { get; } = userVehicle.Key;

    public string UserId { get; } = userVehicle.UserId;

    public string? Doc { get; } = userVehicle.Doc;

    public string? Path { get;} = userVehicle.Path;

    public DateTime? SubmittedOn { get;} = userVehicle.SubmittedOn;

    public long? PermissionLevelId { get; } = userVehicle.PermissionLevelId;

    public long UserVehicleStatusId { get; } = userVehicle.UserVehicleStatusId;

    public bool Favorite { get; } = userVehicle.Favorite;

    
}
