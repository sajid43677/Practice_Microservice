using AutoMapper;
using Core.Domains;
using Service.Models;

namespace Service.Profiles
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            CreateMap<Product, ProductCreateModel>().ReverseMap();
            CreateMap<ProductReadModel, Product>().ReverseMap();
            CreateMap<Product, ProductUpdateModel>().ReverseMap();
        }
    }
}
