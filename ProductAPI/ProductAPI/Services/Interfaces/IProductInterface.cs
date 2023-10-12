using ProductAPI.Models;

namespace ProductAPI.Services.Interfaces
{
  public interface IProductInterface
  {
    Task<IEnumerable<Product>> GetAllProductsAsync();
    Task<string> AddAProductAsync(Product product);
    Task<string> DeleteProductAsync(Product product);
    Task<Product> GetProductByIdAsync(Guid id);
    Task<string> UpdateProductAsync(Product product);
  }
}
