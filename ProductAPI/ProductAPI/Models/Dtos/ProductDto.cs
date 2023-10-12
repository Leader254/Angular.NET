namespace ProductAPI.Models.Dtos
{
  public class ProductDto
  {
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Color { get; set; } = string.Empty;
    public string Type { get; set; } = string.Empty;
    public int Price { get; set; }
    public string ImgUrl { get; set; } = string.Empty;
  }
}
