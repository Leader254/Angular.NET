using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProductAPI.Models;
using ProductAPI.Models.Dtos;
using ProductAPI.Services.Interfaces;

namespace ProductAPI.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class ProductController : ControllerBase
  {
    private readonly IProductInterface _productInterface;
    private readonly IMapper _mapper;
    private readonly ResponseDto _response;

    public ProductController(IProductInterface productInterface, IMapper mapper)
    {
      _productInterface = productInterface;
      _mapper = mapper;
      _response = new ResponseDto();
    }
    [HttpPost]
    public async Task<ActionResult<ResponseDto>> CreateAProduct(ProductRequestDto product)
    {
      var newProduct = _mapper.Map<Product>(product);
      var response = await _productInterface.AddAProductAsync(newProduct);
      if(response.Equals("Product Added Successfully"))
      {
        _response.IsSuccess = true;
        _response.Message = response;
        return Ok(_response);
      }
      _response.IsSuccess = false;
      _response.Message = response;
      return StatusCode(StatusCodes.Status500InternalServerError, _response);
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<ProductDto>>> GetAllProducts()
    {
      var products = await _productInterface.GetAllProductsAsync();
      if(products != null)
      {
        _response.Message = "";
        _response.IsSuccess = true;
        _response.data = products;
        return Ok(products);
      }
      _response.IsSuccess = false;
      _response.Message = "No Products Found";
      return NotFound(_response);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<ResponseDto>> DeletePost(Guid id)
    {
      var product = await _productInterface.GetProductByIdAsync(id);
      if(product != null)
      {
        var response = await _productInterface.DeleteProductAsync(product);
        if(response.Equals("Product Deleted Successfully"))
        {
          _response.IsSuccess = true;
          _response.Message = response;
          return Ok(_response);
        }
        _response.IsSuccess = false;
        _response.Message = "Product Not Found";
        return BadRequest(_response);
      }
      _response.IsSuccess = false;
      _response.Message = "Product Not Found";
      return NotFound(_response);
    }
    [HttpGet("{id}")]
    public async Task<ActionResult<ResponseDto>> GetProductById(Guid id)
    {
      var product = await _productInterface.GetProductByIdAsync(id);
      if(product != null)
      {
        _response.IsSuccess= true;
        _response.Message = "";
        _response.data = product;
        return Ok(product);
      }
      _response.IsSuccess = false;
      _response.Message = "Something went wrong";
      return BadRequest(_response);
    }
    [HttpPut]
    public async Task<ActionResult<ResponseDto>> UpdateProduct(Guid id, ProductRequestDto productRequestDto)
    {
      var product = await _productInterface.GetProductByIdAsync(id);
      if (product != null)
      {
        var productToUpdate = _mapper.Map(productRequestDto, product);
        var response = await _productInterface.UpdateProductAsync(productToUpdate);
        if (response != null)
        {
          _response.IsSuccess = true;
          _response.Message = "Successfully updated";
          return Ok(_response);
        }
        _response.IsSuccess = false;
        _response.Message = "Something went wrong";
        return BadRequest(_response);
      }
      _response.IsSuccess = false;
      _response.Message = "Post not found";
      return BadRequest(_response);
    }
  }
}
