using System.ComponentModel.DataAnnotations;

namespace IALClient.Entity;

public class BaseEntity
{
    
    [Key]
    public long Id { get; set; }
    
    public DateTime Created { get; set; }
    
}