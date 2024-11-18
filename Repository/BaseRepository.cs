using IALClient.Entity;
using IALClient.Infra.Data;
using Microsoft.EntityFrameworkCore;

namespace IALClient.Repository;

public class BaseRepository<T>(ApplicationDbContext context) : IBaseRepository<T> where T : BaseEntity
{
    
    public async Task<List<T>> GetAll()
    {
        return await context.Set<T>().AsNoTracking().ToListAsync();
    }


    public async Task<T?> GetById(long id)
    {
        return await context.Set<T>().FirstOrDefaultAsync(t => t.Id == id);
    }

    public async Task<T> Save(T entity)
    {
        var entry = await context.Set<T>().AddAsync(entity);

        await context.SaveChangesAsync();

        return entry.Entity;
    }

    public async Task Update()
    {
        await context.SaveChangesAsync();
    }

    public async Task Delete(T entity)
    {
        context.Set<T>().Remove(entity);

        await context.SaveChangesAsync();
    }

    public async Task<bool>
        Exists(long id)
    {
        return await context.Set<T>().AnyAsync(t => t.Id == id);
    }
    
}