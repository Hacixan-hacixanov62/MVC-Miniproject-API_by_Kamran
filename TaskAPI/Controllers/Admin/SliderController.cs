using Microsoft.AspNetCore.Mvc;
using TaskAPI.DTOs.Sliders;
using TaskAPI.Services.Interfaces;

namespace TaskAPI.Controllers.Admin
{
    public class SliderController : BaseController
    {
        private readonly ISliderService _sliderService;

        public SliderController(ISliderService sliderService)
        {
            _sliderService = sliderService;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Detail([FromRoute] int id)
        {
            var slider = await _sliderService.GetByIdDetailAsync(id);

            if (slider is null) return NotFound();

            return Ok(slider);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromForm] SliderCreateDto request)
        {
            await _sliderService.CreateAsync(request);

            return CreatedAtAction(nameof(Create), request);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Edit([FromRoute] int id, [FromForm] SliderEditDto request)
        {
            await _sliderService.EditAsync(id, request);

            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> Delete([FromQuery] int? id)
        {
            if (id == null) return BadRequest();

            await _sliderService.DeleteAsync((int)id);

            return Ok();
        }

        
    }
}
