﻿using AutoMapper;
using OnionIntro.Application.DTOs.Tags;
using OnionIntro.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionIntro.Application.MappingProfiles
{
    public class TagProfile : Profile
    {
        public TagProfile()
        {
            CreateMap<Tag, TagCreateDto>().ReverseMap();
            CreateMap<Tag, TagItemDto>().ReverseMap();
            CreateMap<TagItemDto, Tag>();
        }
    }
}
