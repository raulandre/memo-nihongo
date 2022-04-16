using Microsoft.Extensions.Configuration;

namespace Memo.Infra.Utils;

public class DatabaseUtils
{
    private readonly IConfiguration configuration;

    public DatabaseUtils(IConfiguration configuration)
    {
        this.configuration = configuration; 
    }

    public string GetConnectionString()
    {
        var env = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
        if(env == "Production")
        {
            var url = Environment.GetEnvironmentVariable("DATABASE_URL");
            var host = url.Split("@")[1].Split("/")[0];
            var database = url.Split("@")[1].Split("/")[1];
            var username = url.Remove(0, "postgres://".Length).Split(":")[0];
            var password = url.Remove(0, "postgres://".Length).Split(":")[1].Split("@")[0];

            return $"Host={host};Database={database};Username={username};Password={password}";
        }
        
        return configuration.GetConnectionString("PostgreSQL");
    }
}