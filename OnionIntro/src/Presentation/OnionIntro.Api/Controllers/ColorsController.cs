using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnionIntro.Application.Abstractions.Services;
using OnionIntro.Application.DTOs.Colors;

namespace OnionIntro.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ColorsController : ControllerBase
    {
        private readonly IColorService _service;

        public ColorsController(IColorService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> Get(int page = 1, int take = 3)
        {
            return Ok(await _service.GetAllAsync(page, take));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            return Ok(await _service.GetByIdAsync(id));
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromForm] ColorCreateDto colorDto)
        {
            await _service.CreateAsync(colorDto);
            return StatusCode(StatusCodes.Status201Created);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromForm] ColorUpdateDto colorDto)
        {
            if (id <= 0) return StatusCode(StatusCodes.Status400BadRequest);
            await _service.UpdateAsync(id, colorDto);
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
