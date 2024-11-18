using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IALClient.Entity;

[Table("PermissionLevels")]
public class PermissionLevel : BaseEntity
{
    
    [MaxLength(50)]
    public string Code { get; set; }

    [MaxLength(255)]
    public string Description { get; set; }
    
    public PermissionLevel () { }

    public PermissionLevel(string code, string description)
    {
        Code = code;
        Description = description;
        Created = DateTime.UtcNow;
    }

}
