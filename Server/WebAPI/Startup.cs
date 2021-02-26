using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Shared.Context;
using WebAPI.Extensions;

namespace WebAPI {
  public class Startup {
    public IConfiguration config { get; }
    public Startup(IConfiguration configuration) => config = configuration;

    // This method gets called by the runtime. Use this method to add services to the container.
    public void ConfigureServices(IServiceCollection services) {
      services
        .SetDependencies()
        .SetAuthentication(config)
        .SetEntityFramework(config)
        .SetIdentity()
        .SetControllers()
        .SetSwaggerDocs()
        .AddCors();
    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder builder, IWebHostEnvironment env) {
      builder
        .UseCors(options => options.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin())
        .UseDeveloperExceptionPage()
        .ScaffoldProfile()
        .UseSwaggerDocs()
        .UseAuthentication()
        .UseRouting()
        .UseAuthorization()
        .UseEndpoints(endpoints => endpoints.MapControllers());
    }
  }
}