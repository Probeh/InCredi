using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Shared.Models;

namespace Shared.Context {
  /* Encapsulates Generic Declarations & Intended For Inheritence By Context.cs Only */
  public class BaseContext : IdentityDbContext<User, Role, int, IdentityUserClaim<int>, UserRole, IdentityUserLogin<int>, IdentityRoleClaim<int>, IdentityUserToken<int>> {
    public BaseContext(DbContextOptions options) : base(options) { }
  }
}