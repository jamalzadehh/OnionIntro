using AutoMapper;
using OnionIntro.Application.DTOs.Products;
using OnionIntro.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionIntro.Application.MappingProfiles
{
    public class ProductProfile:Profile
    {
        public ProductProfile()
        {
            CreateMap<Product, ProductItemDto>().ReverseMap();
            CreateMap<Product, ProductGetDto>().ReverseMap();
            CreateMap<ProductCreateDto,Product>().ReverseMap();
            CreateMap<ProductUpdateDto,Product>().ReverseMap();
        }
    }
}
