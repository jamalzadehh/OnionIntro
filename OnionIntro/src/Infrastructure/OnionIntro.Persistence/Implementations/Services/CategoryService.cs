using AutoMapper;
using Microsoft.EntityFrameworkCore;
using OnionIntro.Application.Abstractions.Repositories;
using OnionIntro.Application.Abstractions.Services;
using OnionIntro.Application.DTOs.Categories;
using OnionIntro.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionIntro.Persistence.Implementations.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _repository;
        private readonly IMapper _mapper;

        public CategoryService(ICategoryRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<ICollection<CategoryItemDto>> GetAllAsync(int page, int take)
        {
            ICollection<Category> categories = await _repository.GetAllAsync(skip: (page - 1) * take, take: take, isTracking: false).ToListAsync();
            ICollection<CategoryItemDto> categoryDtos = _mapper.Map<ICollection<CategoryItemDto>>(categories);


            return categoryDtos;
        }
        public async Task CreateAsync(CategoryCreateDto categoryDto)
        {


            await _repository.AddAsync(_mapper.Map<Category>(categoryDto));
            await _repository.SaveChangesAsync();
        }

        public async Task UpdateAsync(int id, CategoryUpdateDto categoryDto)
        {
            Category category = await _repository.GetByIdAsync(id);

            if (category == null) throw new Exception("Not Found");

            category.Name = categoryDto.Name;

            _repository.Update(category);
            await _repository.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            Category category = await _repository.GetByIdAsync(id);
            if (category is null) throw new Exception("Not found");
            _repository.Delete(category);
            await _repository.SaveChangesAsync();
        }

        //public async Task<GetCategoryDto> GetAsync(int id)
        //{
        //    Category category = await _repository.GetByIdAsync(id);
        //    if (category == null) throw new Exception("Not Found");
        //    return new GetCategoryDto { Id = category.Id, Name = category.Name };
        //}
    }
}
