using AutoMapper;
using OnionIntro.Application.DTOs.Categories;
using OnionIntro.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionIntro.Application.MappingProfiles
{
    public class CategoryProfile:Profile
    {
        public CategoryProfile()
        {
            CreateMap<Category, CategoryItemDto>().ReverseMap();
            CreateMap<CategoryCreateDto, Category>();
            CreateMap<CategoryUpdateDto, Category>().ReverseMap();
            CreateMap<Category, IncludeCategoryDto>().ReverseMap();
            CreateMap<Category, CategoryGetDto>().ReverseMap();

        }
    }
}
