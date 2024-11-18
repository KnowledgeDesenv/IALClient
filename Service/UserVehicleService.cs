using IALClient.DTO.Request.register;
using IALClient.DTO.Request.update;
using IALClient.DTO.Response;
using IALClient.Entity;
using IALClient.Infra.ExternalApi;
using IALClient.Mapper;
using IALClient.Repository;
using IALClient.Service.CustomException;
using IALClient.Util;

namespace IALClient.Service;

public class UserVehicleService(UserVehicleRepository repository, UserService userService, UserVehicleStatusService userVehicleStatusService, PermissionLevelService permissionLevelService, UploadFileService uploadFileService, ConfigService configService, TinyDogService tinyDogService)
{

    
    public async Task<List<UserVehicleResponseDto>> GetAll(int page, int rows)
    {

        var userVehicles = await repository.GetAll(page, rows);

        return UserVehicleMapper.ToDtoList(userVehicles);
    }

    public async Task<UserVehicleResponseDto> GetById(long id)
    {
        
        var userVehicle = await RecoverUserVehicle(id);

        return UserVehicleMapper.ToDto(userVehicle);
    }

    public async Task<List<UserVehicleResponseDto>> GetByUserId(string userId)
    {

        await userService.RecoverUser(userId);
        
        var userVehicles = await repository.GetByUserId(userId);

        return UserVehicleMapper.ToDtoList(userVehicles);
    }

    public async Task<UserVehicleResponseDto> Save(UserVehicleRegisterDto userVehicleRegisterDto, string userLoggedId) 
    {

        var vinWrapper = await tinyDogService.GetVehicleVin(userVehicleRegisterDto.Key);

        UserVehicle userVehicle = new(userVehicleRegisterDto.Key, vinWrapper.VIN, userLoggedId);

        var hasAnotherUserVehicleAsFavorite = await repository.HasAnotherUserVehicleAsFavorite(userLoggedId);

        if (!hasAnotherUserVehicleAsFavorite)
        {
            userVehicle.Favorite = true;
        }

   
        var userVehicleStatusId = await Utils.ManageUserVehicleStatus(userVehicleRegisterDto.UserVehicleType, configService);
        await AssociateUserVehicleStatus(userVehicle, userVehicleStatusId);

        userVehicle = await repository.Save(userVehicle);
        
        return UserVehicleMapper.ToDto(userVehicle);
    }

    public async Task<UserVehicleResponseDto> Update(UserVehicleUpdateDto userVeichleUpdateDto, long userVehicleId, string userId)
    {

        var userVehicle = await RecoverUserVehicle(userVehicleId);

        var vinWrapper = await tinyDogService.GetVehicleVin(userVeichleUpdateDto.Key);

        UserVehicleMapper.Update(userVeichleUpdateDto, userVehicle);

        var userVehicleStatusId = await Utils.ManageUserVehicleStatus(userVeichleUpdateDto.UserVehicleType, configService);
        await AssociateUserVehicleStatus(userVehicle, userVehicleStatusId);
        await AssociatePermissionLevel(userVehicle, userVeichleUpdateDto.PermissionLevelId);

        userVehicle.LastModified = DateTime.UtcNow;
        userVehicle.ModifiedBy = userId;
        userVehicle.Vin = vinWrapper.VIN;

        await repository.Update();

        return UserVehicleMapper.ToDto(userVehicle);
    }

    public async Task UpdateAsFavorite(long userVehicleId, string userLoggedId)
    {

        var userVehicle = await RecoverUserVehicle(userVehicleId);

        if(userVehicle.UserId != userLoggedId)
        {
            throw new UnauthorizedAccessException(); // Tratar no program.cs
        }

        var removeAsFavorite = await repository.getAnotherUserVehicleAsFavorite(userLoggedId);

        if(removeAsFavorite != null)
        {
            removeAsFavorite.Favorite = false;
        }

        userVehicle.Favorite = true;

        await repository.Update();

    }

    public async Task<UserVehicleResponseDto> SubmitDocument(ICollection<IFormFile> images, long id, string userLoggedId)
    {

        var (fileName, entirePath) = await uploadFileService.SubmitDocumentUserVehicle(images);
      
        var userVehicle = await RecoverUserVehicle(id);

        SetDocument(userVehicle, fileName, entirePath, userLoggedId);

        await repository.Update();

        return UserVehicleMapper.ToDto(userVehicle);
    }


    public async Task Delete(long id, string userLoggedId) 
    {
        
        var userVehicle = await RecoverUserVehicle(id);

        if (userVehicle.UserId != userLoggedId)
        {
            throw new UnauthorizedAccessException();
        }

        var existingNextVehicle = await repository.ExistingNextUserVehicle(userLoggedId);

        if(userVehicle.Favorite && existingNextVehicle != null)
        {
            existingNextVehicle.Favorite = true;
        }

        await repository.Delete(userVehicle);

    }

    private async Task AssociateUserVehicleStatus(UserVehicle userVehicle, long userVehicleStatusId)
    {
        if(userVehicle.UserVehicleStatus == null || userVehicle.UserVehicleStatusId != userVehicleStatusId) 
        {
            userVehicle.UserVehicleStatus = await userVehicleStatusService.RecoverUserVehicleStatus(userVehicleStatusId);
        }
    }

    private async Task AssociatePermissionLevel(UserVehicle userVehicle, long? permissionLevelId)
    {
        if(permissionLevelId != null && (userVehicle.PermissionLevel == null || userVehicle.PermissionLevelId != permissionLevelId))
        {
            userVehicle.PermissionLevel = await permissionLevelService.RecoverPermissionLevel(permissionLevelId.Value);
        }
    }

    private void SetDocument(UserVehicle userVehicle, string fileName, string entirePath, string userId)
    {
        userVehicle.Doc = fileName;
        userVehicle.Path = entirePath;
        userVehicle.SubmittedOn = DateTime.UtcNow;
        userVehicle.LastModified = DateTime.UtcNow;
        userVehicle.ModifiedBy = userId;
    }

    private async Task<UserVehicle> RecoverUserVehicle(long id)
    {

        var userVehicle = await repository.GetById(id);

        if(userVehicle == null) 
        {
            throw new ResourceNotFoundException("The userVehicle id: " + id + " wasn't found in the database");
        }


        return userVehicle;
    }

  

}
