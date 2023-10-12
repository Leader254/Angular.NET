namespace ProductAPI.Models.Dtos
{
  public class ResponseDto
  {
    public bool IsSuccess { get; set; }
    public object? data { get; set; }
    public string Message { get; set; } = string.Empty;
  }
}
