using IALClient.DTO.Request.register;
using IALClient.DTO.Request.update;
using IALClient.DTO.Response;
using IALClient.Entity;
using IALClient.Infra.Data;
using IALClient.Mapper;
using IALClient.Service.CustomException;
using Microsoft.EntityFrameworkCore;

namespace IALClient.Service;

public class ConfigService(ApplicationDbContext context)
{
    
    public async Task<List<ConfigResponseDto>> GetAll(int page, int rows)
    {
        
        var configs = await context.Config.AsNoTracking()
            .Skip((page - 1) * rows).Take(rows)
            .ToListAsync();

        return ConfigMapper.ToDtoList(configs);
    }

    public async Task<ConfigResponseDto> GetById(long id)
    {
        var config = await RecoverConfig(id);

        return ConfigMapper.ToDto(config);
    }

    public async Task<Config> GetFirst()
    {
       return await context.Config.FirstAsync();
    }


    public async Task<ConfigResponseDto> Save(ConfigRegisterDto configRegisterDto, string userId)
    {

        var config = ConfigMapper.ToEntity(configRegisterDto);
        config.CreatedBy = userId;

        var entry = await context.Config.AddAsync(config);

        await context.SaveChangesAsync();

        return ConfigMapper.ToDto(entry.Entity);
    }

    public async Task<ConfigResponseDto> Update(ConfigUpdateDto configUpdateDto, long id, string userId)
    {

        var config = await RecoverConfig(id);
        ConfigMapper.Update(configUpdateDto, config);

        config.LastModified = DateTime.UtcNow;
        config.ModifiedBy = userId;

        await context.SaveChangesAsync();

        return ConfigMapper.ToDto(config);
    }

    public async Task Delete(long id) 
    {

        var config = await RecoverConfig(id);

        context.Config.Remove(config);

        await context.SaveChangesAsync();

    }

    private async Task<Config> RecoverConfig(long id)
    {
        var config = await context.Config.FirstOrDefaultAsync(c => c.Id == id);

        if (config == null)
        {
            throw new ResourceNotFoundException("The config id: " + id + " wasn't found in the database");
        }

        return config;
    }

}
