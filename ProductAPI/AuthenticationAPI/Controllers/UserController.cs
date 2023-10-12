using AuthenticationAPI.Models.Dtos;
using AuthenticationAPI.Services.IServices;
using Azure;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AuthenticationAPI.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class UserController : ControllerBase
  {
    private IUserInterface _userInterface;
    private readonly ResponseDto _response;
    private readonly IConfiguration _configuration;

    public UserController(IUserInterface userInterface, IConfiguration configuration)
    {
        _userInterface = userInterface;
        _configuration = configuration;
        _response = new ResponseDto();
    }

    [HttpPost("register")]
    public async Task<ActionResult<ResponseDto>> AddUser(RegisterUserDto registerUser)
    {
      var errorMessage = await _userInterface.RegisterUser(registerUser);
      if(!string.IsNullOrEmpty(errorMessage))
      {
        //meaning we have an error
        _response.IsSuccess = false;
        _response.Message = errorMessage;

        return BadRequest(_response);
      }
      _response.Message = "User Created Successfully";
      _response.IsSuccess = true;
      return Ok(_response);
    }

    [HttpPost("login")]
    public async Task<ActionResult<ResponseDto>> LoginUser(LoginUserDto loginUser)
    {
      var response = await _userInterface.Login(loginUser);
      if(response.User == null)
      {
        _response.IsSuccess = false;
        _response.Message = "Invalid Credential";

        return BadRequest(_response);
      }

      _response.data = response;
      return Ok(_response);
    }
  }
}
