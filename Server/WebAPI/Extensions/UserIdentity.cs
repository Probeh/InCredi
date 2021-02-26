using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using Shared.Context;
using Shared.Models;

namespace WebAPI.Extensions {
  public static partial class Extension {
    public static IServiceCollection SetIdentity(this IServiceCollection services) =>
      services
      .AddDefaultIdentity<User>(options => {
        options.Password.RequireDigit = false;
        options.Password.RequireLowercase = false;
        options.Password.RequireNonAlphanumeric = false;
        options.Password.RequireUppercase = false;
        options.SignIn.RequireConfirmedAccount = false;
        options.SignIn.RequireConfirmedEmail = false;
        options.SignIn.RequireConfirmedPhoneNumber = false;
        options.User.RequireUniqueEmail = false;
      })
      .AddRoles<Role>()
      .AddEntityFrameworkStores<ApplicationContext>()
      .AddRoleManager<RoleManager<Role>>()
      .AddRoleValidator<RoleValidator<Role>>()
      .AddUserManager<UserManager<User>>()
      .AddSignInManager<SignInManager<User>>()
      .AddUserValidator<UserValidator<User>>().Services
      .AddAuthentication(JwtBearerDefaults.AuthenticationScheme).Services;
  }
}