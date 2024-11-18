using IALClient.DTO.Request.register;
using IALClient.DTO.Request.update;
using IALClient.DTO.Response;
using IALClient.Entity;

namespace IALClient.Mapper;

public class UserVehicleMapper
{

    public static UserVehicleResponseDto ToDto(UserVehicle userVehicle)
    {
        return new UserVehicleResponseDto(userVehicle);
    }

    public static void Update(UserVehicleUpdateDto userVehicleDto, UserVehicle userVehicle) 
    { 
        userVehicle.Key = userVehicleDto.Key;
    }

    public static List<UserVehicleResponseDto> ToDtoList(List<UserVehicle> userVehicles) 
    { 
        return userVehicles.Select(ToDto).ToList();
    }

}
