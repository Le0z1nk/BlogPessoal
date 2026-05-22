using BlogPessoal.Data;
using Microsoft.EntityFrameworkCore;

namespace BlogPessoal.Config;

public static class ConfigDbContext
{
    public static IServiceCollection AddDatabaseContext(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("PostgresConnection");
        services.AddDbContext<AppDbContext>(options => options.UseNpgsql(connectionString));

        return services;
    }
}
