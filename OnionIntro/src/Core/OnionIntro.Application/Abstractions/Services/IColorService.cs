using OnionIntro.Application.DTOs.Colors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionIntro.Application.Abstractions.Services
{
    public interface IColorService
    {
        Task<ICollection<ColorItemDto>> GetAllAsync(int page, int take);
        Task<ColorGetDto> GetByIdAsync(int id);
        Task CreateAsync(ColorCreateDto colorDto);
        Task UpdateAsync(int id, ColorUpdateDto colorDto);
        Task DeleteAsync(int id);
        Task SoftDeleteAsync(int id);
        Task ReverseDeleteAsync(int id);
    }
}
