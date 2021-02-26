using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Shared.Context;

namespace WebAPI.Extensions {
  public static partial class Extensions {
    public static IServiceCollection SetEntityFramework(this IServiceCollection services, IConfiguration configuration) {
      return services.AddDbContext<ApplicationContext>(options => {
        var connectionString = configuration.GetConnectionString("Default");
        options.EnableDetailedErrors()
          .EnableSensitiveDataLogging()
          .UseSqlServer(connectionString, c => c.MigrationsAssembly("WebAPI"));
        services.AddDatabaseDeveloperPageExceptionFilter();
      });
    }
  }
}