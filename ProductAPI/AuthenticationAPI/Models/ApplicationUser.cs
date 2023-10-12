using Microsoft.AspNetCore.Identity;

namespace AuthenticationAPI.Models
{
  public class ApplicationUser : IdentityUser
  {
    public string Name { get; set; } = string.Empty;
  }
}
