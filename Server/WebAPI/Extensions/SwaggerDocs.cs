using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

namespace WebAPI.Extensions {
  public static partial class Extensions {
    public static IServiceCollection SetSwaggerDocs(this IServiceCollection services) {
      services.AddSwaggerGen(x => {
        var securityScheme = new OpenApiSecurityScheme() {
        BearerFormat = "HmacSHA512",
        In = ParameterLocation.Header,
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey
        };
        x.AddSecurityDefinition("Bearer Token", securityScheme);
        x.AddSecurityRequirement(new OpenApiSecurityRequirement());
        x.CustomOperationIds(x => x.RelativePath.Replace("api/", ""));
        x.CustomSchemaIds(x => x.Name);
        x.DescribeAllParametersInCamelCase();
        x.EnableAnnotations();
        x.OrderActionsBy(x => x.RelativePath);
        x.SwaggerDoc("v1", new OpenApiInfo { Title = "InCredi Documentation", Version = "v1.0" });
        x.UseAllOfToExtendReferenceSchemas();
        x.UseInlineDefinitionsForEnums();
      });
      return services;
    }
    public static IApplicationBuilder UseSwaggerDocs(this IApplicationBuilder app) {
      app.UseSwagger();
      app.UseReDoc(x => {
        x.DocumentTitle = "InCredi Documentation";
        x.RoutePrefix = "v1/docs";
        x.SpecUrl = "/swagger/v1/swagger.json";
        x.RequiredPropsFirst();
        x.SortPropsAlphabetically();
      });
      return app;
    }
  }
}