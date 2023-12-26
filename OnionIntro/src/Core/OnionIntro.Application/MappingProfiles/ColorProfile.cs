using AutoMapper;
using OnionIntro.Application.DTOs.Colors;
using OnionIntro.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionIntro.Application.MappingProfiles
{
    public class ColorProfile:Profile
    {
        public ColorProfile()
        {
            CreateMap<Color,ColorItemDto>().ReverseMap();
            CreateMap<ColorCreateDto, Color>();
            CreateMap<ColorUpdateDto, Color>().ReverseMap();
            CreateMap<Color, ColorGetDto>().ReverseMap();
        }
    }
}
