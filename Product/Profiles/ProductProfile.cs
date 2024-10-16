﻿using AutoMapper;
using ProductService.DTOs;
using ProductService.Models;

namespace ProductService.Profiles
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            CreateMap<Product, ProductReadDto>().ReverseMap();
            CreateMap<ProductCreateDto, Product>().ReverseMap();
        }
    }
}
