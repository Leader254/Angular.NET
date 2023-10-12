using AutoMapper;
using ProductAPI.Models;
using ProductAPI.Models.Dtos;

namespace ProductAPI.Profiles
{
  public class ProductProfile : Profile
  {
    public ProductProfile()
    {
        CreateMap<ProductRequestDto, Product>().ReverseMap();
        CreateMap<Product, ProductDto>().ReverseMap();
    }
  }
}
