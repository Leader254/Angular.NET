namespace AuthenticationAPI.Models.Dtos
{
  public class ResponseDto
  {
    public string Message { get; set; } = string.Empty;
    public object? data { get; set; }
    public bool IsSuccess { get; set; } = true;
  }
}
