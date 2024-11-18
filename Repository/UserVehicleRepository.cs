using IALClient.Entity;
using IALClient.Infra.Data;
using Microsoft.EntityFrameworkCore;

namespace IALClient.Repository;

public class UserVehicleRepository(ApplicationDbContext context) : BaseRepository<UserVehicle>(context)
{
    
    public async Task<List<UserVehicle>> GetAll(int page, int rows)
    {

        return await context.UserVehicle.AsNoTracking()
            .Skip((page - 1) * rows)
            .Take(rows)
            .ToListAsync();
    }

    public async Task<List<UserVehicle>> GetByUserId(string userId)
    {
        return await context.UserVehicle.Where(v => v.UserId == userId).ToListAsync();
    }
    
    public async Task<bool> HasAnotherUserVehicleAsFavorite(string userId)
    {
        return await context.UserVehicle.AnyAsync(u => u.UserId == userId && u.Favorite == true);
    }
    
    public async Task<UserVehicle?> getAnotherUserVehicleAsFavorite(string userId)
    {
        return await context.UserVehicle.Where(u => u.UserId == userId && u.Favorite).FirstOrDefaultAsync();
    }
    
    public async Task<UserVehicle?> ExistingNextUserVehicle(string userId)
    {
        return await context.UserVehicle.Where(u => u.UserId == userId).FirstOrDefaultAsync();
    }
    
    
}