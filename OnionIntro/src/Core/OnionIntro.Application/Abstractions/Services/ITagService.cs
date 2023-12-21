using OnionIntro.Application.DTOs.Tags;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionIntro.Application.Abstractions.Services
{
    public interface ITagService
    {
        Task<ICollection<TagItemDto>> GetAllAsync(int page, int take);
        //Task<GetTagDto> GetAsync(int id);
        Task CreateAsync(TagCreateDto tagDto);
        Task UpdateAsync(int id, TagUpdateDto updateTagDto);
        Task DeleteAsync(int id);
    }
}
