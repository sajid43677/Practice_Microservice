using AutoMapper;
using Products.DTOs;

namespace Products.Profiles
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            CreateMap<Models.Product, ProductReadDto>().ReverseMap();
            CreateMap<ProductCreateDto, Models.Product>().ReverseMap();
        }
    }
}
