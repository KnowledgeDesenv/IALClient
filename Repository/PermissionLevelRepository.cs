using IALClient.Entity;
using IALClient.Infra.Data;
using Microsoft.EntityFrameworkCore;

namespace IALClient.Repository;

public class PermissionLevelRepository(ApplicationDbContext context) : BaseRepository<PermissionLevel>(context)
{
    
    public async Task<List<PermissionLevel>> GetAll(int page, int rows)
    {

        return await context.PermissionLevel.AsNoTracking()
            .Skip((page - 1) * rows)
            .Take(rows)
            .ToListAsync();
    }
    
}