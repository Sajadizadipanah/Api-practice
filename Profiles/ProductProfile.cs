using API_Practice.Dtos;
using API_Practice.Models;
using AutoMapper;

namespace API_Practice.Profiles;

public class ProductProfile : Profile
{
    public ProductProfile()
    {
 
        CreateMap<AddProductDto, Product>();
        CreateMap<Product, ProductDto>();
    }
}
