using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace IALClient.Entity;

public class ApplicationUser : IdentityUser
{

    [MaxLength(255)]
    public string Name { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime Created { get; set; }

    public string? ModifiedBy { get; set; }

    public DateTime? LastModified { get; set; }

    [MaxLength(20)]
    public string? Code { get; set; }

    public ApplicationUser () { }

    public ApplicationUser(string email, string name)
    {
        UserName = email;
        Email = email;
        Name = name;
        Created = DateTime.UtcNow;
    }

}
