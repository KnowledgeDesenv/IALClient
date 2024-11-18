using IALClient.DTO.Request.register;
using IALClient.DTO.Request.update;
using IALClient.DTO.Response;
using IALClient.Entity;
using IALClient.Infra.Data;
using IALClient.Mapper;
using IALClient.Repository;
using IALClient.Service.CustomException;
using Microsoft.EntityFrameworkCore;

namespace IALClient.Service;

public class UserVehicleStatusService(UserVehicleStatusRepository repository)
{
    
    public async Task<List<UserVehicleStatusResponseDto>> GetAll(int page, int rows)
    {
        
        var userVehicleStatus = await repository.GetAll(page, rows);

        return UserVehicleStatusMapper.ToDtoList(userVehicleStatus);
    }

    public async Task<UserVehicleStatusResponseDto> GetById(long id)
    {

        var userVehicleStatus = await RecoverUserVehicleStatus(id);

        return UserVehicleStatusMapper.ToDto(userVehicleStatus);
    }

    public async Task<UserVehicleStatusResponseDto> Save(UserVehicleStatusRegisterDto userVehicleStatusRegisterDto)
    {

        var userVehicleStatus = UserVehicleStatusMapper.ToEntity(userVehicleStatusRegisterDto);
        
        userVehicleStatus = await repository.Save(userVehicleStatus);
        
        return UserVehicleStatusMapper.ToDto(userVehicleStatus);
    }

    public async Task<UserVehicleStatusResponseDto> Update(UserVehicleStatusUpdateDto userVehicleStatusUpdateDto, long id)
    {

        var userVehicleStatus = await RecoverUserVehicleStatus(id);

        UserVehicleStatusMapper.Update(userVehicleStatusUpdateDto, userVehicleStatus);

        await repository.Update();

        return UserVehicleStatusMapper.ToDto(userVehicleStatus);
    }

    public async Task Delete(long id)
    {

        var userVehicleStatus = await RecoverUserVehicleStatus(id);

        await repository.Delete(userVehicleStatus);
    }

    public async Task<UserVehicleStatus> RecoverUserVehicleStatus(long id)
    {
        var userVehicleStatus = await repository.GetById(id);

        if (userVehicleStatus == null)
        {
            throw new ResourceNotFoundException("The UserVehicleStatus id: " + id + " wasn't found in the database");
        }
    
        return userVehicleStatus;
    }

}
