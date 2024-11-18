using IALClient.DTO.Request.register;
using IALClient.DTO.Request.update;
using IALClient.DTO.Response;
using IALClient.Entity;

namespace IALClient.Mapper;

public class UserVehicleStatusMapper
{

    public static UserVehicleStatus ToEntity(UserVehicleStatusRegisterDto userVehicleStatusDto)
    {
        return new UserVehicleStatus(userVehicleStatusDto.Status);
    }

    public static UserVehicleStatusResponseDto ToDto(UserVehicleStatus userVehicleStatus) 
    { 
        return new UserVehicleStatusResponseDto(userVehicleStatus);
    }

    public static void Update(UserVehicleStatusUpdateDto userVehicleDto, UserVehicleStatus userVehicleStatus) 
    {
        userVehicleStatus.Status = userVehicleDto.Status;
    }

    public static List<UserVehicleStatusResponseDto> ToDtoList(List<UserVehicleStatus> userVehicleStatus)
    {
        return userVehicleStatus.Select(ToDto).ToList();
    }

}
