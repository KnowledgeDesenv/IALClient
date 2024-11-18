using IALClient.DTO.Request.register;
using IALClient.DTO.Request.update;
using IALClient.DTO.Response;
using IALClient.Entity;

namespace IALClient.Mapper;

public class PermissionLevelMapper
{

    public static PermissionLevel ToEntity(PermissionLevelRegisterDto permissionLevelDto)
    {
        return new PermissionLevel(permissionLevelDto.Code, permissionLevelDto.Description);
    }

    public static PermissionLevelResponseDto ToDto(PermissionLevel permissionLevel)
    {
        return new PermissionLevelResponseDto(permissionLevel);
    }

    public static void Update(PermissionLevelUpdateDto permissionLevelDto, PermissionLevel permissionLevel)
    {
        permissionLevel.Code = permissionLevelDto.Code;
        permissionLevel.Description = permissionLevelDto.Description;
    }

    public static List<PermissionLevelResponseDto> ToDtoList(List<PermissionLevel> permissionLevels) 
    {
        return permissionLevels.Select(ToDto).ToList();
    }

}
