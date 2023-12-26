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
            ICollection<Category> categories = await _repository.GetAllWhere(skip: (page - 1) * take, take: take, isTracking: false,ignoreQuery:true).ToListAsync();
            ICollection<CategoryItemDto> categoryDtos = _mapper.Map<ICollection<CategoryItemDto>>(categories);


            return categoryDtos;
        }
        public async Task CreateAsync(CategoryCreateDto categoryDto)
        {
            bool result = await _repository.IsExistAsync(c => c.Name == categoryDto.Name);
            if (result) throw new Exception("Already exist");
            await _repository.AddAsync(_mapper.Map<Category>(categoryDto));
            await _repository.SaveChangesAsync();
        }

        public async Task UpdateAsync(int id, CategoryUpdateDto categoryDto)
        {
            Category category = await _repository.GetByIdAsync(id);
            if (category is null) throw new Exception("Not found");

            bool result = await _repository.IsExistAsync(c => c.Name == categoryDto.Name);
            if (result) throw new Exception("Already exist");

            _mapper.Map(categoryDto, category);
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

        public async Task SoftDeleteAsync(int id)
        {
           Category category= await _repository.GetByIdAsync(id);
            if (category is null) throw new Exception("Not Found");
            _repository.SoftDelete(category);
            await _repository.SaveChangesAsync();

        }

        public async Task<CategoryGetDto> GetByIdAsync(int id)
        {
            if(id <= 0) throw new Exception("Bad Request");
            Category item = await _repository.GetByIdAsync(id, includes: nameof(Category.Products));
            if (item == null) throw new Exception("Not Found");

            CategoryGetDto dto = _mapper.Map<CategoryGetDto>(item);

            return dto;
        }

        public async Task ReverseDeleteAsync(int id)
        {
            Category category = await _repository.GetByIdAsync(id, ignoreQuery: true);
            if (category is null) throw new Exception("Not found");
            _repository.ReverseSoftDelete(category);
            await _repository.SaveChangesAsync();
        }

        
        
    }
}
