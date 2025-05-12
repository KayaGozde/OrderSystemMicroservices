using ProductService.Dtos;
using ProductService.ResponseModels;

namespace ProductService.Interfaces
{
    public interface IProductService
    {
        Task<List<ProductResponse>> GetAllAsync();
        Task<ProductResponse> AddAsync(ProductDto dto);
    }
}