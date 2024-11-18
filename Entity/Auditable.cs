namespace IALClient.Entity;

public class Auditable : BaseEntity
{
    
    public string? CreatedBy { get; set; }

    public string? ModifiedBy { get; set; }

    public DateTime? LastModified { get; set; }

}
