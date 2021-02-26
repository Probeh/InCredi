using System.Text.Json;
using Microsoft.Extensions.DependencyInjection;

namespace WebAPI.Extensions {
  public static partial class Extension {
    public static IServiceCollection SetControllers(this IServiceCollection services) =>
      services
      .AddControllers()
      .AddNewtonsoftJson()
      .AddJsonOptions(x => x.JsonSerializerOptions.PropertyNamingPolicy = JsonNamingPolicy.CamelCase)
      .AddJsonOptions(x => x.JsonSerializerOptions.MaxDepth = 0)
      .AddJsonOptions(x => x.JsonSerializerOptions.WriteIndented = true)
      .Services;
  }
}