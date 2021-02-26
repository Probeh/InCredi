using Microsoft.Extensions.DependencyInjection;
using Shared.Services;

namespace WebAPI.Extensions {
  public static partial class Extension {
    public static IServiceCollection SetDependencies(this IServiceCollection services) =>
      services
      .AddScoped<ProfileRepository>()
      .AddScoped<UserRepository>();
  }
}