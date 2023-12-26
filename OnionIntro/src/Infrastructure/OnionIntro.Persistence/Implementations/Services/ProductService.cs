using AutoMapper;
using Microsoft.EntityFrameworkCore;
using OnionIntro.Application.Abstractions.Repositories;
using OnionIntro.Application.Abstractions.Services;
using OnionIntro.Application.DTOs.Products;
using OnionIntro.Domain.Entities;

namespace OnionIntro.Persistence.Implementations.Services
{
    public class ProductService:IProductService
    {
        private readonly IProductRepository _repository;
        private readonly ICategoryRepository _catrepository;
        private readonly IColorRepository _colrepository;
        private readonly ITagRepository _tagrepository;
        private readonly IMapper _mapper;

        public ProductService(IProductRepository repository, IMapper mapper, ICategoryRepository catrepository, IColorRepository colrepository, ITagRepository tagrepository)
        {
            _repository = repository;
            _mapper = mapper;
            _catrepository = catrepository;
            _colrepository = colrepository;
            _tagrepository = tagrepository;
        }

        public async Task CreateAsync(ProductCreateDto productDto)
        {
            bool result = await _repository.IsExistAsync(c => c.Name == productDto.Name);
            if (result) throw new Exception("Product already exist");

            result = await _catrepository.IsExistAsync(c => c.Id == productDto.CategoryId);
            if (!result) throw new Exception("Category not found");

            Product product = _mapper.Map<Product>(productDto);

            product.ProductColors = new List<ProductColor>();
            foreach (var colorId in productDto.ColorIds)
            {
                if (!await _colrepository.IsExistAsync(x => x.Id == colorId)) throw new Exception("Color not found.");
                product.ProductColors.Add(new ProductColor
                {
                    ColorId = colorId
                });
            }

            product.ProductTags = new List<ProductTag>();
            foreach (var tagid in productDto.TagIds)
            {
                if (!await _tagrepository.IsExistAsync(x => x.Id == tagid)) throw new Exception("Tag not found.");
                product.ProductTags.Add(new ProductTag
                {
                    TagId = tagid
                });
            }

            await _repository.AddAsync(product);
            await _repository.SaveChangesAsync();
        }
        public async Task UpdateAsync(int id, ProductUpdateDto productDto)
        {
            string[] include = { $"{nameof(Product.ProductColors)}", $"{nameof(Product.ProductTags)}" };
            Product existed = await _repository.GetByIdAsync(id, includes: include);
            if (existed is null) throw new Exception("Not found");

            if (productDto.CategoryId != existed.CategoryId)
                if (!await _catrepository.IsExistAsync(c => c.Id == productDto.CategoryId))
                    throw new Exception("Category Not Found");

            existed = _mapper.Map(productDto, existed);

            existed.ProductColors = existed.ProductColors.Where(pc => productDto.ColorIds.Any(colid => pc.ColorId == colid)).ToList();
            foreach (var colorId in productDto.ColorIds)
            {
                if (!await _colrepository.IsExistAsync(x => x.Id == colorId)) throw new Exception("Color not found.");
                if (!existed.ProductColors.Any(pc => pc.ColorId == colorId))
                {
                    existed.ProductColors.Add(new ProductColor
                    {
                        ColorId = colorId
                    });
                }
            }

            existed.ProductTags = existed.ProductTags.Where(pt => productDto.TagIds.Any(tagid => pt.TagId == tagid)).ToList();
            foreach (var tagid in productDto.TagIds)
            {
                if (!await _tagrepository.IsExistAsync(x => x.Id == tagid)) throw new Exception("Tag not found.");
                if (!existed.ProductTags.Any(pt => pt.TagId == tagid))
                {
                    existed.ProductTags.Add(new ProductTag
                    {
                        TagId = tagid
                    });
                }
            }

            _repository.Update(existed);
            await _repository.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            Product product = await _repository.GetByIdAsync(id);
            if (product is null) throw new Exception("Not found");
            _repository.Delete(product);
            await _repository.SaveChangesAsync();
        }

       

        public async Task<IEnumerable<ProductItemDto>> GetAllPaginated(int page,int take)
        {
            IEnumerable<ProductItemDto> dtos = _mapper.Map<IEnumerable<ProductItemDto>>(await _repository.GetAllWhere(skip: (page - 1) * take, take: take, isTracking: false).ToArrayAsync());
            return dtos;            
        }
        public async Task<ProductGetDto> GetByIdAsync(int id)
        {
            if (id <= 0) throw new Exception("Bad Request");
            Product item = await _repository.GetByIdAsync(id, includes: nameof(Product.Category));
            if (item == null) throw new Exception("Not Found");
            ProductGetDto dto = _mapper.Map<ProductGetDto>(item);

            return dto;
        }

        public async Task ReverseDeleteAsync(int id)
        {
            Product product = await _repository.GetByIdAsync(id, ignoreQuery: true);
            if (product is null) throw new Exception("Not found");
            _repository.ReverseSoftDelete(product);
            await _repository.SaveChangesAsync();
        }

        public async Task SoftDeleteAsync(int id)
        {
            Product product = await _repository.GetByIdAsync(id);
            if (product is null) throw new Exception("Not found");
            _repository.SoftDelete(product);
            await _repository.SaveChangesAsync();
        }


       
    }
}
