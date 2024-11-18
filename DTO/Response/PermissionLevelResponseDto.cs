using IALClient.Entity;

namespace IALClient.DTO.Response;

public class PermissionLevelResponseDto(PermissionLevel permissionLevel)
{

    public long Id { get; } = permissionLevel.Id;

    public string Code { get; } = permissionLevel.Code;

    public string Description { get; } = permissionLevel.Description;
    
}
