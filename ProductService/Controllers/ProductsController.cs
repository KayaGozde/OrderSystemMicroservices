using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ProductService.Interfaces;
using ProductService.RequestModels;
using ProductService.Dtos;

namespace ProductService.Controllers
{
    [ApiController]
    [Route("api/products")]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;
        private readonly IMapper _mapper;

        public ProductController(IProductService productService, IMapper mapper)
        {
            _productService = productService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var products = await _productService.GetAllAsync();
            return Ok(products);
        }

        [HttpPost]
        public async Task<IActionResult> Add(ProductRequest request)
        {
            var dto = _mapper.Map<ProductDto>(request);
            var result = await _productService.AddAsync(dto);
            return Ok(result);
        }
    }
}