using IALClient.Entity;
using IALClient.Infra.Data;
using Microsoft.EntityFrameworkCore;

namespace IALClient.Repository;

public class UserVehicleStatusRepository(ApplicationDbContext context) : BaseRepository<UserVehicleStatus>(context)
{
    
    public async Task<List<UserVehicleStatus>> GetAll(int page, int rows)
    {

        return await context.UserVehicleStatus.AsNoTracking()
            .Skip((page - 1) * rows)
            .Take(rows)
            .ToListAsync();
    }
    
}