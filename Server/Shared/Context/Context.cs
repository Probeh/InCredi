using Microsoft.EntityFrameworkCore;
using Shared.Models;

namespace Shared.Context {
  public class ApplicationContext : BaseContext {
    public DbSet<User> Accounts { get; set; }
    public DbSet<Profile> Profiles { get; set; }
    public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options) { }
  }
}