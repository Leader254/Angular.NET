using AuthenticationAPI.Context;
using AuthenticationAPI.Models;
using AuthenticationAPI.Models.Dtos;
using AuthenticationAPI.Services.IServices;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace AuthenticationAPI.Services
{
  public class UserService : IUserInterface
  {
    private readonly AppDbContext _context;
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly RoleManager<IdentityRole> _roleManager;
    private readonly IMapper _mapper;
    private readonly IJWTTokenGenerator _jwtTokenGenerator;

    public UserService(AppDbContext context, UserManager<ApplicationUser> userManager, IJWTTokenGenerator tokenGen, RoleManager<IdentityRole> roleManager, IMapper mapper)
    {
      _userManager = userManager;
      _roleManager = roleManager;
      _mapper = mapper;
      _context = context;
      _jwtTokenGenerator = tokenGen;
    }
    public Task<bool> AssignUserRole(string email, string Rolename)
    {
      throw new NotImplementedException();
    }

    public async Task<LoginResponseDto> Login(LoginUserDto loginUserDto)
    {
      var user = await _context.ApplicationUsers.FirstOrDefaultAsync(u => u.UserName.ToLower() == loginUserDto.Username.ToLower());
      var passValid = await _userManager.CheckPasswordAsync(user, loginUserDto.Password);
      if(!passValid || user == null)
      {
        new LoginResponseDto();
      }
      var roles = await _userManager.GetRolesAsync(user);
      var token = _jwtTokenGenerator.GenerateToken(user, roles);

      var loggedUser = new LoginResponseDto()
      {
        User = _mapper.Map<UserDto>(user),
        Token = token,
      };

      return loggedUser;
    }

    public async Task<string> RegisterUser(RegisterUserDto registerUserDto)
    {
      var user = _mapper.Map<ApplicationUser>(registerUserDto);
      try
      {
        var result = await _userManager.CreateAsync(user , registerUserDto.Password);
        if (result.Succeeded)
        {
          return "";
        }
        else
        {
          return result.Errors.FirstOrDefault().Description;
        }
      }
      catch (Exception ex)
      {
        return ex.Message;
      }
    }
  }
}
