using AuthenticationAPI.Models;

namespace AuthenticationAPI.Services.IServices
{
  public interface IJWTTokenGenerator
  {
    string GenerateToken(ApplicationUser user, IEnumerable<string> roles);
  }
}
