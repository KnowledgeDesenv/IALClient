using IALClient.Entity;

namespace IALClient.DTO.Response;

public class UserVehicleStatusResponseDto(UserVehicleStatus userVehicleStatus)
{

    public long Id { get; } = userVehicleStatus.Id;

    public string Status { get; } = userVehicleStatus.Status;
    
}
