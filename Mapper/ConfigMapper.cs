using IALClient.DTO.Request.register;
using IALClient.DTO.Request.update;
using IALClient.DTO.Response;
using IALClient.Entity;

namespace IALClient.Mapper;

public class ConfigMapper
{

    public static Config ToEntity(ConfigRegisterDto configDto)
    {
       return new Config(configDto.ApiMapKey, configDto.ApiURL, configDto.ApiUser, configDto.ApiPassword);
    }

    public static ConfigResponseDto ToDto(Config config)
    {
        return new ConfigResponseDto(config);
    }

    public static void Update(ConfigUpdateDto configDto, Config config)
    {
        config.ApiMapKey = configDto.ApiMapKey;
        config.ApiURL = configDto.ApiURL;
        config.ApiUser = configDto.ApiUser;
        config.ApiPassword = configDto.ApiPassword;
    }

    public static List<ConfigResponseDto> ToDtoList(List<Config> configs)
    {
        return configs.Select(ToDto).ToList();
    }

}
