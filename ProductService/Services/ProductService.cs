using AutoMapper;
using ProductService.Data;
using ProductService.Dtos;
using ProductService.Interfaces;
using ProductService.Models;
using ProductService.ResponseModels;

namespace ProductService.Services
{
    public class ProductService : IProductService
    {
        private readonly ProductDbContext _context;
        private readonly IMapper _mapper;

        public ProductService(ProductDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<ProductResponse>> GetAllAsync()
        {
            var products = _context.Products.ToList();
            return _mapper.Map<List<ProductResponse>>(products);
        }

        public async Task<ProductResponse> AddAsync(ProductDto dto)
        {
            var product = _mapper.Map<Product>(dto);
            _context.Products.Add(product);
            await _context.SaveChangesAsync();
            return _mapper.Map<ProductResponse>(product);
        }
    }
}