using IALClient.Service.CustomException;
using IALClient.Service;

namespace IALClient.Util;

public class Utils
{

    public const string FilesFolder = "Uploads";

    private const string UserVehicleTypeOwner = "OWNER";

    private const string UserVehicleTypeShared = "SHARED";

    public static async Task<long> ManageUserVehicleStatus(string userVehicleType, ConfigService configService)
    {

        var config = await configService.GetFirst();
        
        return userVehicleType.ToUpper() switch
        {
            UserVehicleTypeShared => config.SharedUserVehicleStatusId,
            UserVehicleTypeOwner => config.OwnerUserVehicleStatusId,
            _ => throw new InvalidTypeException(userVehicleType)
        };

    }

}
