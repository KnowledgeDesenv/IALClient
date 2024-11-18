using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IALClient.Entity;

[Table("Config")]
public class Config : Auditable
{
    
    [MaxLength(255)]
    public string ApiMapKey { get; set; }

    [MaxLength(255)]
    public string ApiURL { get; set; }

    [MaxLength(50)]
    public string ApiUser { get; set; }

    [MaxLength(100)]
    public string ApiPassword { get; set; }

    public long SharedUserVehicleStatusId { get; set; }

    public long OwnerUserVehicleStatusId { get; set; }

    public Config(string apiMapKey, string apiURL, string apiUser, string apiPassword)
    {
        ApiMapKey = apiMapKey;
        ApiURL = apiURL;
        ApiUser = apiUser;
        ApiPassword = apiPassword;
        Created = DateTime.UtcNow;
    }


}
