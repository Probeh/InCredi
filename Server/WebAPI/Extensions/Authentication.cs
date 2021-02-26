using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;

namespace WebAPI.Extensions {
  public static partial class Extension {
    public static IServiceCollection SetAuthentication(this IServiceCollection services, IConfiguration config) =>
      services
      .AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
      .AddJwtBearer(options => new TokenParams(config, "Signature", validateAudience : false, validateIssuer : false, validateSignature : true))
      .Services;
  }
  public class TokenParams : TokenValidationParameters {
    public TokenParams(IConfiguration config, string keyName, bool validateAudience, bool validateIssuer, bool validateSignature) {
      base.ValidateAudience = validateAudience;
      base.ValidateIssuer = validateIssuer;
      base.ValidateIssuerSigningKey = validateSignature;
      base.IssuerSigningKey = SetSigningKey(config, keyName);
    }
    public SymmetricSecurityKey SetSigningKey(IConfiguration config, string keyName) {
      return new SymmetricSecurityKey(Encoding.ASCII.GetBytes(config.GetSection($"AppSettings:{keyName}").Value));
    }
  }
}