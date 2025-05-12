using AutoMapper;
using ProductService.Dtos;
using ProductService.Models;
using ProductService.RequestModels;
using ProductService.ResponseModels;

namespace ProductService.Mappings
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            CreateMap<Product, ProductResponse>();
            CreateMap<ProductDto, Product>();
            CreateMap<ProductRequest, ProductDto>();
        }
    }
}