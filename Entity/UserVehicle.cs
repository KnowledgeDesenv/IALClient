using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IALClient.Entity;

[Table("UserVehicles")]
public class UserVehicle : Auditable
{
    
    [MaxLength(17)]
    public string Vin {  get; set; }

    [MaxLength(50)]
    public string Key { get; set; }

    public string? Doc {  get; set; }

    public string? Path { get; set; }

    public DateTime? SubmittedOn { get; set; }

    public string UserId { get; set; }

    public ApplicationUser User { get; set; }

    public long? PermissionLevelId { get; set; }

    public PermissionLevel? PermissionLevel { get; set; }

    public long UserVehicleStatusId { get; set; }

    public UserVehicleStatus UserVehicleStatus { get; set; }

    public bool Favorite { get; set; }

    public UserVehicle () { }

  
    public UserVehicle(string key, string vin, string userId) 
    {
        Key = key;
        Vin = vin;
        UserId = userId;
        CreatedBy = userId;
        Created = DateTime.UtcNow;
    }

    public UserVehicle(string vin, string key, ApplicationUser user, long userVehicleStatusId, bool favorite)
    {
        Vin = vin;
        Key = key;
        User = user;
        UserVehicleStatusId = userVehicleStatusId;
        Created = DateTime.UtcNow;
        Favorite = favorite;
    }

}
