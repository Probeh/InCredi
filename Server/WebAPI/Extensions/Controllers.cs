using System.Text.Json;
using Microsoft.Extensions.DependencyInjection;

namespace WebAPI.Extensions {
  public static partial class Extension {
    public static IServiceCollection SetControllers(this IServiceCollection services) =>
      services
      .AddControllers()
      .AddNewtonsoftJson()
      .AddJsonOptions(options => {
        options.JsonSerializerOptions.AllowTrailingCommas = false;
        options.JsonSerializerOptions.MaxDepth = 0;
        options.JsonSerializerOptions.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;
        options.JsonSerializerOptions.WriteIndented = true;
      }).Services;
  }
}