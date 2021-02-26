using Microsoft.AspNetCore.Identity;

namespace Shared.Models {
  public class UserRole : IdentityUserRole<int> {
    public Role Role { get; set; }
    public User User { get; set; }
  }
}