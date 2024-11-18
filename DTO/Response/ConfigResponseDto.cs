using IALClient.Entity;

namespace IALClient.DTO.Response;

public class ConfigResponseDto(Config config) // Coloar os 2 campos novos!!!!!!!!!!
{

    public long Id { get; } = config.Id;

    public string ApiMapKey { get; } = config.ApiMapKey;

    public string ApiURL { get; } = config.ApiURL;

    public string ApiUser { get; } = config.ApiUser;

    public long SharedUserVehicleStatusId { get; } = config.SharedUserVehicleStatusId;

    public long OwnerUserVehicleStatusId { get; } = config.OwnerUserVehicleStatusId;
    
}
