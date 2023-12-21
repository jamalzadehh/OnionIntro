using AutoMapper;
using Microsoft.EntityFrameworkCore;
using OnionIntro.Application.Abstractions.Repositories;
using OnionIntro.Application.Abstractions.Services;
using OnionIntro.Application.DTOs.Tags;
using OnionIntro.Domain.Entities;
using OnionIntro.Persistence.Implementations.Repositories.Generic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionIntro.Persistence.Implementations.Services
{
    public class TagService : ITagService
    {
        private readonly ITagRepository _repository;

        private readonly IMapper _mapper;
        public TagService(ITagRepository tagRepository, IMapper mapper)
        {
            _repository = tagRepository;
            _mapper = mapper;
        }

        public async Task CreateAsync(TagCreateDto tagDto)
        {
            await _repository.AddAsync(_mapper.Map<Tag>(tagDto));
            await _repository.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            Tag tag = await _repository.GetByIdAsync(id);
            if (tag is null) throw new Exception("Not found");
            _repository.Delete(tag);
            await _repository.SaveChangesAsync();
        }

        public async Task<ICollection<TagItemDto>> GetAllAsync(int page, int take)
        {
            ICollection<Tag> tags = await _repository.GetAllAsync(skip: (page - 1) * take, take: take, isTracking: false).ToListAsync();
            var tagDtos = _mapper.Map<ICollection<TagItemDto>>(tags);
            return tagDtos;
        }

        public async Task UpdateAsync(int id, TagUpdateDto updateTagDto)
        {
            Tag tag = await _repository.GetByIdAsync(id);

            if (tag == null) throw new Exception("Not Found");

            tag.Name = updateTagDto.Name;

            _repository.Update(tag);
            await _repository.SaveChangesAsync();
        }
    }
}
