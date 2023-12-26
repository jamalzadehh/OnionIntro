using OnionIntro.Application.DTOs.Categories;
using OnionIntro.Application.DTOs.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionIntro.Application.Abstractions.Services
{
    public interface IProductService
    {
        Task<IEnumerable<ProductItemDto>> GetAllPaginated(int page, int take);
        Task<ProductGetDto> GetByIdAsync(int id);
        Task CreateAsync(ProductCreateDto create);
        Task DeleteAsync(int id);
        Task SoftDeleteAsync(int id);
        Task ReverseDeleteAsync(int id);
        Task UpdateAsync(int id, ProductUpdateDto productDto);
    }
}
