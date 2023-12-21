using Microsoft.AspNetCore.Mvc;
using OnionIntro.Application.Abstractions.Repositories;
using OnionIntro.Application.Abstractions.Services;
using OnionIntro.Application.DTOs.Tags;

namespace OnionIntro.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TagsController : ControllerBase
    {
        private readonly ITagService _service;

        public TagsController(ITagService service)
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
        public async Task<IActionResult> Create([FromForm] TagCreateDto createTagDto)
        {
            await _service.CreateAsync(createTagDto);
            return StatusCode(StatusCodes.Status201Created);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromForm] TagUpdateDto updateTagDto)
        {
            if (id <= 0) return BadRequest();
            await _service.UpdateAsync(id, updateTagDto);
            return NoContent();

        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            if (id <= 0) return BadRequest();
            await _service.DeleteAsync(id);
            return NoContent();
        }


    }
}
