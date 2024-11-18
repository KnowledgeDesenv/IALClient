
using IALClient.Entity;
using IALClient.Entity.Projection;
using IALClient.Service.CustomException;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace IALClient.Repository;

public class UserRepository(UserManager<ApplicationUser> userManager)
{
    
    public async Task<List<UserProjection>> GetAll(int page, int rows)

    {
        return await userManager.Users.AsNoTracking()
            .Skip((page - 1) * rows).Take(rows)
            .Select(u => new UserProjection
            (
                u.Id, 
                u.Email!, 
                u.Name
            ))
            .ToListAsync();
    }

    public async Task<ApplicationUser?> GetById(string id)
    {
        return await userManager.FindByIdAsync(id);
        
    }

    public async Task<ApplicationUser?> GetByEmail(string email)
    {
        return await userManager.FindByEmailAsync(email);
    }
    
    
    public async Task Save(ApplicationUser user, string password)
    {
        
        var saveIdentity = await userManager.CreateAsync(user, password);

        if (!saveIdentity.Succeeded) throw new CreateUserException(saveIdentity.Errors.First().Description);

    }
    
    public async Task ChangePasswordUserLogged(ApplicationUser user, string newPassword)
    {
        
        await userManager.RemovePasswordAsync(user);

        await userManager.AddPasswordAsync(user, newPassword);
    }
    
    public async Task Update(ApplicationUser user)
    {
        
        await userManager.UpdateAsync(user);
        
    }
    
}