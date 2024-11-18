using IALClient.Entity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace IALClient.Infra.Data;

public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
{

    private readonly IConfiguration _configuration;

    public DbSet<UserVehicle> UserVehicle { get; set; }

    public DbSet<UserVehicleStatus> UserVehicleStatus { get; set; }

    public DbSet<Config> Config { get; set; }

    public DbSet<PermissionLevel> PermissionLevel { get; set; }


    public ApplicationDbContext(IConfiguration configuration)
    {
        _configuration = configuration;
        AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
    }

    protected override void OnConfiguring(DbContextOptionsBuilder options)
    {
        options.UseNpgsql(_configuration.GetConnectionString("WebApiDatabase"));
        options.LogTo(Console.WriteLine);
        //Console.WriteLine($"WebApiDatabase Connectionstring => {_configuration.GetConnectionString("WebApiDatabase")}");
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

    }


}
