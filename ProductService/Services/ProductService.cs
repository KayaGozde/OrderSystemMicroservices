using AutoMapper;
using ProductService.Data;
using ProductService.Dtos;
using ProductService.Helpers;
using ProductService.Interfaces;
using ProductService.Models;
using ProductService.ResponseModels;

namespace ProductService.Services
{
    public class ProductService : IProductService
    {
        private readonly ProductDbContext _context;
        private readonly IMapper _mapper;
        private readonly KafkaProducerHelper _kafkaProducerHelper;      

        public ProductService(ProductDbContext context, IMapper mapper, KafkaProducerHelper kafkaProducerHelper)
        {       
            _context = context;
            _mapper = mapper;
            _kafkaProducerHelper = kafkaProducerHelper;
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

            var message = new
            {
                Event = "ProductCreated",
                Data = new
                {
                    product.Id,
                    product.Name,
                    product.Stock,
                    product.Price,
                    CreatedAt = DateTime.UtcNow
                }
            };

            try
            {

                await _kafkaProducerHelper.ProduceAsync("product-events", message);
            }
            catch (Exception ex)
            {

                Console.WriteLine("KAFKA HATASI:" + ex.Message);
            }

            return _mapper.Map<ProductResponse>(product);
        }


    }
}