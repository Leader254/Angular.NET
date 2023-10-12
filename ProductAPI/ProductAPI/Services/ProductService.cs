using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ProductAPI.Context;
using ProductAPI.Models;
using ProductAPI.Services.Interfaces;

namespace ProductAPI.Services
{
  public class ProductService : IProductInterface
  {
    private readonly IMapper _mapper;
    private readonly AppDbContext _context;
    public ProductService(AppDbContext context, IMapper mapper)
    {
      _mapper = mapper;
      _context = context;
    }
    public async Task<string> AddAProductAsync(Product product)
    {
      await _context.Products.AddAsync(product);
      await _context.SaveChangesAsync();
      return "Product Added Successfully";
    }

    public async Task<string> DeleteProductAsync(Product product)
    {
      _context.Products.Remove(product);
      await _context.SaveChangesAsync();
      return "Product Deleted Successfully";
    }

    public async Task<IEnumerable<Product>> GetAllProductsAsync()
    {
      var products = await _context.Products.ToListAsync();
      return products;
    }

    public async Task<Product> GetProductByIdAsync(Guid id)
    {
      var product = await _context.Products.Where(x => x.Id == id).FirstOrDefaultAsync();
      if(product != null)
      {
        return product;
      }
      return new Product { Id = id };
    }

    public async Task<string> UpdateProductAsync(Product product)
    {
      _context.Products.Update(product);
      await _context.SaveChangesAsync();
      return "Product Updated Successfully";
    }
  }
}
