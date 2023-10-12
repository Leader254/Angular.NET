using AuthenticationAPI.Models.Dtos;

namespace AuthenticationAPI.Services.IServices
{
  public interface IUserInterface
  {
    Task<string> RegisterUser(RegisterUserDto registerUserDto);
    Task<LoginResponseDto> Login(LoginUserDto loginUserDto);
    Task<bool> AssignUserRole(string email, string Rolename);
  }
}
