using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnionIntro.Application.Abstractions.Services;
using OnionIntro.Application.DTOs.Products;

namespace OnionIntro.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _service;

        public ProductsController(IProductService service)
        {
            _service = service;
        }
        [HttpGet]
        public async Task<IActionResult> Get(int page, int take)
        {
            return Ok(await _service.GetAllPaginated(page, take));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            return Ok(await _service.GetByIdAsync(id));
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromForm] ProductCreateDto productDto)
        {
            await _service.CreateAsync(productDto);
            return StatusCode(StatusCodes.Status201Created);
        }

        [HttpPut]
        public async Task<IActionResult> Update(int id, [FromForm] ProductUpdateDto productDto)
        {
            if (id <= 0) return StatusCode(StatusCodes.Status400BadRequest);
            await _service.UpdateAsync(id, productDto);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _service.DeleteAsync(id);
            return NoContent();
        }
        [HttpDelete("SoftDelete/{id}")]
        public async Task<IActionResult> SoftDelete(int id)
        {
            await _service.SoftDeleteAsync(id);
            return NoContent();
        }

        [HttpPatch("{id}")]
        public async Task<IActionResult> ReverseSoftDelete(int id)
        {
            if (id <= 0) return StatusCode(StatusCodes.Status400BadRequest);
            await _service.ReverseDeleteAsync(id);
            return NoContent();
        }

    }
}
