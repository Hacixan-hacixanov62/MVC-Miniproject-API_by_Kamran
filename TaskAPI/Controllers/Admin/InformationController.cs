using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TaskAPI.DTOs.Informations;
using TaskAPI.Services.Interfaces;

namespace TaskAPI.Controllers.Admin
{
    public class InformationController : BaseController
    {
        private readonly IInformationService _informationService;

        public InformationController(IInformationService informationService)
        {
            _informationService = informationService;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Detail([FromRoute] int id)
        {
            var information = await _informationService.GetByIdDetailAsync(id);

            if (information == null) return NotFound();

            return Ok(information);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] InformationCreateDto request)
        {
            if (await _informationService.ExistAsync(request.Title))
            {
                ModelState.AddModelError("Title", "Information with this title already exists");
                return BadRequest(ModelState);
            }

            await _informationService.CreateAsync(request);

            return CreatedAtAction(nameof(Create), request);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Edit([FromRoute] int id, [FromBody] InformationEditDto request)
        {
            if (await _informationService.ExistExceptByIdAsync(id, request.Title))
            {
                ModelState.AddModelError("Title", "Information with this title already exists");
                return BadRequest(ModelState);
            }

            await _informationService.EditAsync(id, request);

            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> Delete([FromQuery] int? id)
        {
            if (id == null) return BadRequest();

            await _informationService.DeleteAsync((int)id);

            return Ok();
        }
    }
}
