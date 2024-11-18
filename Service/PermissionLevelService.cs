using IALClient.DTO.Request.register;
using IALClient.DTO.Request.update;
using IALClient.DTO.Response;
using IALClient.Entity;
using IALClient.Mapper;
using IALClient.Repository;
using IALClient.Service.CustomException;

namespace IALClient.Service;

public class PermissionLevelService(PermissionLevelRepository repository)
{
    
    public async Task<List<PermissionLevelResponseDto>> GetAll(int page, int rows)
    {

        var permissionLevels = await repository.GetAll(page, rows);

        return PermissionLevelMapper.ToDtoList(permissionLevels);
    }

    public async Task<PermissionLevelResponseDto> GetById(long id) 
    {

        var permissionLevel = await RecoverPermissionLevel(id);

        return PermissionLevelMapper.ToDto(permissionLevel);    
    }

    public async Task<PermissionLevelResponseDto> Save(PermissionLevelRegisterDto permissionLevelRegisterDto)
    {

        var permissionLevel = PermissionLevelMapper.ToEntity(permissionLevelRegisterDto);

        permissionLevel = await repository.Save(permissionLevel);
        
        return PermissionLevelMapper.ToDto(permissionLevel);
    }

    public async Task<PermissionLevelResponseDto> Update(PermissionLevelUpdateDto permissionLevelUpdateDto, long id)
    {
        
        var permissionLevel = await RecoverPermissionLevel(id);

        PermissionLevelMapper.Update(permissionLevelUpdateDto, permissionLevel);

        await repository.Update();

        return PermissionLevelMapper.ToDto(permissionLevel);
    }

    public async Task Delete(long id)
    {

        var permissionLevel = await RecoverPermissionLevel(id);

        await repository.Delete(permissionLevel);
    }

    public async Task<PermissionLevel> RecoverPermissionLevel(long id)
    {

        var permissionLevel = await repository.GetById(id);

        if(permissionLevel == null)
        {
            throw new ResourceNotFoundException("The PermissionLevel id: " + id + " wasn't found in the database");
        }

        return permissionLevel;
    }

}
