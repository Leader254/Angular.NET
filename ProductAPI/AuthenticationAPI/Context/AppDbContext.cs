using AuthenticationAPI.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace AuthenticationAPI.Context
{
  public class AppDbContext : IdentityDbContext<ApplicationUser>
  {
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
    public DbSet<ApplicationUser> ApplicationUsers { get; set; }
  }
}
