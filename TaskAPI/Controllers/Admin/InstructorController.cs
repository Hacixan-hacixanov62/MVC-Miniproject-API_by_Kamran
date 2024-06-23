using Microsoft.AspNetCore.Mvc;
using TaskAPI.DTOs.Instructors;
using TaskAPI.Services.Interfaces;

namespace TaskAPI.Controllers.Admin
{
    public class InstructorController : BaseController
    {
        private readonly IInstructorService _instructorService;

        public InstructorController(IInstructorService instructorService)
        {
            _instructorService = instructorService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _instructorService.GetAllAsync());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Detail([FromRoute] int id)
        {
            var instructor = await _instructorService.GetByIdDetailAsync(id);

            if (instructor == null) return NotFound();

            return Ok(instructor);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromForm] InstructorCreateDto request)
        {
            await _instructorService.CreateAsync(request);

            return CreatedAtAction(nameof(Create), request);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Edit([FromRoute] int id, [FromForm] InstructorEditDto request)
        {
            await _instructorService.EditAsync(id, request);

            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> Delete([FromQuery] int? id)
        {
            if (id == null) return BadRequest();

            await _instructorService.DeleteAsync((int)id);

            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> AddSocial([FromBody] InstructorSocialAddDto request)
        {
            await _instructorService.AddSocialAsync(request);

            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> DeleteSocial([FromQuery] int? instructorSocialId)
        {
            if (instructorSocialId == null) return BadRequest();

            await _instructorService.DeleteSocialAsync((int)instructorSocialId);

            return Ok();
        }
    }
}
