using AutoMapper;
using Microsoft.EntityFrameworkCore;
using OnionIntro.Application.Abstractions.Repositories;
using OnionIntro.Application.Abstractions.Services;
using OnionIntro.Application.DTOs.Colors;
using OnionIntro.Domain.Entities;

namespace OnionIntro.Persistence.Implementations.Services
{
    public class ColorService:IColorService
    {
        private readonly IColorRepository _repository;
        private readonly IMapper _mapper;

        public ColorService(IColorRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<ICollection<ColorItemDto>> GetAllAsync(int page, int take)
        {
            ICollection<Color> Colors = await _repository.GetAllWhere(skip: (page - 1) * take, take: take, isTracking: false).ToListAsync();
            var ColorDtos = _mapper.Map<ICollection<ColorItemDto>>(Colors);
            return ColorDtos;
        }

        public async  Task CreateAsync(ColorCreateDto ColorDto)
        {
            bool result = await _repository.IsExistAsync(c => c.Name == ColorDto.Name);
            if (result) throw new Exception("Already exist");

            await _repository.AddAsync(_mapper.Map<Color>(ColorDto));
            await _repository.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            Color Color = await _repository.GetByIdAsync(id);
            if (Color is null) throw new Exception("Not found");
            _repository.Delete(Color);
            await _repository.SaveChangesAsync();
        }

        public async Task SoftDeleteAsync(int id)
        {
            Color Color = await _repository.GetByIdAsync(id);
            if (Color is null) throw new Exception("Not found");
            _repository.SoftDelete(Color);
            await _repository.SaveChangesAsync();
        }
        public async Task ReverseDeleteAsync(int id)
        {
            Color color = await _repository.GetByIdAsync(id, ignoreQuery: true);
            if (color is null) throw new Exception("Not found");
            _repository.ReverseSoftDelete(color);
            await _repository.SaveChangesAsync();
        }
        public async Task UpdateAsync(int id, ColorUpdateDto ColorDto)
        {
            Color Color = await _repository.GetByIdAsync(id);

            bool result = await _repository.IsExistAsync(c => c.Name == ColorDto.Name);
            if (result) throw new Exception("Already exist");

            if (Color is null) throw new Exception("Not found");
            _mapper.Map(ColorDto, Color);
            _repository.Update(Color);
            await _repository.SaveChangesAsync();
        }


        public async Task<ColorGetDto> GetByIdAsync(int id)
        {
            if (id <= 0) throw new Exception("Bad Request");
            string[] include = { $"{nameof(Color.ProductColors)}.{nameof(ProductColor.Product)}" };
            Color item = await _repository.GetByIdAsync(id, includes: include);
            if (item == null) throw new Exception("Color not found");
            ColorGetDto dto = _mapper.Map<ColorGetDto>(item);

            return dto;
        }


    }
}
