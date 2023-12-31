﻿using OnionIntro.Application.DTOs.Categories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionIntro.Application.Abstractions.Services
{
    public interface ICategoryService
    {
        Task<ICollection<CategoryItemDto>> GetAllAsync(int page, int take);
        Task<CategoryGetDto> GetByIdAsync(int id);
        Task CreateAsync(CategoryCreateDto categoryDto);
        Task UpdateAsync(int id, CategoryUpdateDto categoryDto);
        Task DeleteAsync(int id);
        Task SoftDeleteAsync(int id);
        Task ReverseDeleteAsync(int id);
    }
}
