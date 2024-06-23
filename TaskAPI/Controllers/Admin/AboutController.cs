using Microsoft.AspNetCore.Mvc;
using TaskAPI.DTOs.Abouts;
using TaskAPI.Services.Interfaces;

namespace TaskAPI.Controllers.Admin
{
    public class AboutController : BaseController
    {
        private readonly IAboutService _aboutService;

        public AboutController(IAboutService aboutService)
        {
            _aboutService = aboutService;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Detail([FromRoute] int id)
        {
            var about = await _aboutService.GetByIdDetailAsync(id);

            if (about is null) return NotFound();

            return Ok(about);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromForm] AboutCreateDto request)
        {
            await _aboutService.CreateAsync(request);

            return CreatedAtAction(nameof(Create), request);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Edit([FromRoute] int id, [FromForm] AboutEditDto request)
        {
            await _aboutService.EditAsync(id, request);

            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> Delete([FromQuery] int? id)
        {
            if (id == null) return BadRequest();
            await _aboutService.DeleteAsync((int)id);

            return Ok();
        }
    }
}
