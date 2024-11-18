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

public class UserService(UserRepository repository, UserVehicleRepository userVehicleRepository, TinyDogService tinyDogService, ConfigService configService)
{
    
    public async Task<List<UserResponseDto>> GetAll(int page, int rows) // buscando dto diretamente do banco, fazer projection!

    {

        var userProjections = await repository.GetAll(page, rows);

        return UserMapper.ToDtoList(userProjections);

    }

    public async Task<UserResponseDto> GetById(string id)
    {
        
        var user = await RecoverUser(id);

        return UserMapper.ToDto(user);
    }

    public async Task<UserResponseDto> Save(UserRegisterDto userRegisterDto, string userLoggedId)
    {

        var user = UserMapper.ToEntity(userRegisterDto);
        user.CreatedBy = userLoggedId;

        await repository.Save(user, userRegisterDto.Password);

        return UserMapper.ToDto(user);
    }

    public async Task<UserWithUserVehicleResponseDto> SaveWithUserVehicle(UserWithUserVehicleRegisterDto registerDto)
    {

        var user = new ApplicationUser(registerDto.Email, registerDto.Name);
 
        var vinWrapper = await tinyDogService.GetVehicleVin(registerDto.Key);
       
        var userVehicle = await CreateUserVehicle(vinWrapper.VIN, registerDto.Key, user, registerDto.UserVehicleType);
        
        await repository.Save(user, registerDto.Password);

        userVehicle = await userVehicleRepository.Save(userVehicle);
        
        return new UserWithUserVehicleResponseDto(user, userVehicle);
    }

    public async Task ChangePasswordUserLogged(ChangePasswordUserLoggedDto wrapper, string userLoggedId)
    {
        
       var user = await RecoverUser(userLoggedId);

       await repository.ChangePasswordUserLogged(user, wrapper.NewPassword);
    }

    public async Task<ApplicationUser> RecoverUser(string id) 
    {
        var user = await repository.GetById(id);

        if (user == null)
        {
            throw new ResourceNotFoundException("The User id: " + id + " wasn't found in the database");
        }

        return user;
    }

    public async Task<ApplicationUser> RecoverUserByEmail(string email)
    {
        var user = await repository.GetByEmail(email);

        if (user == null)
        {
            throw new ResourceNotFoundException("The email: " + email + " wasn't found in the database");
        }

        return user;
    }
    
    private async Task<UserVehicle> CreateUserVehicle(string vin, string key, ApplicationUser user, string userVehicleType)
    {

        var userVehicleStatusId = await Utils.ManageUserVehicleStatus(userVehicleType, configService);

        return new UserVehicle(vin, key, user, userVehicleStatusId, true);
   
                                                                            // Nesse caso é true pois esse método será chamado apenas quando for criado UserVehicle junto Com User, então seria o primeiro UserVehicle desse user, então, por default, vem como favorito, apenas nesse fluxo.
    }

    
}
