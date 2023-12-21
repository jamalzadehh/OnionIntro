using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnionIntro.Application.Abstractions.Services;
using OnionIntro.Application.DTOs.Categories;

namespace OnionIntro.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryService _service;

        public CategoriesController(ICategoryService service)
        {
            _service = service;
        }
        [HttpGet]
        public async Task<IActionResult> Get(int page, int take)
        {
            return Ok(await _service.GetAllAsync(page, take));
        }
        //[HttpGet("{id}")]
        //public async Task<IActionResult> Get(int id)
        //{
        //    if (id <= 0) return BadRequest();
        //    return Ok(await _service.GetAsync(id));
        //}
        [HttpPost]
        public async Task<IActionResult> Create([FromForm] CategoryCreateDto categoryDto)
        {
            await _service.CreateAsync(categoryDto);
            return StatusCode(StatusCodes.Status201Created);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromForm] CategoryUpdateDto updateDto)
        {
            if (id <= 0) return BadRequest();
            await _service.UpdateAsync(id, updateDto);
            return NoContent();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            if (id <= 0) return BadRequest();
            await _service.DeleteAsync(id);
            return NoContent();
        }
        [HttpDelete]
        public async Task<IActionResult> SoftDelete(int id)
        {
            if (id <= 0) return StatusCode(StatusCodes.Status400BadRequest);
            await _service.SoftDeleteAsync(id);
            return NoContent();
        }
    }

}
