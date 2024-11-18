using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IALClient.Entity;

[Table("UserVehicleStatus")]
public class UserVehicleStatus : BaseEntity
{
    
    [MaxLength(50)]
    public string Status { get; set; }
    
    public UserVehicleStatus() { }

    public UserVehicleStatus(string status) 
    {
        Status = status;
        Created = DateTime.UtcNow;
    }

}
