using Microsoft.AspNetCore.Identity;
using Shared.Context;
using Shared.Models;

namespace Shared.Services {
  public class UserRepository {
    private readonly ApplicationContext context;
    private readonly UserManager<User> userManager;
    private readonly SignInManager<User> signinManager;

    public UserRepository(ApplicationContext context, UserManager<User> userManager, SignInManager<User> signinManager) {
      this.context = context;
      this.userManager = userManager;
      this.signinManager = signinManager;
    }
  }
}