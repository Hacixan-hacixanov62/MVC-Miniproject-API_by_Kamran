using Microsoft.AspNetCore.Mvc;
using TaskAPI.DTOs.Socials;
using TaskAPI.Services.Interfaces;

namespace TaskAPI.Controllers.Admin
{
    public class SocialController : BaseController
    {
        private readonly ISocialService _socialService;

        public SocialController(ISocialService socialService)
        {
            _socialService = socialService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _socialService.GetAllAsync());
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromForm] SocialCreateDto request)
        {
            if (await _socialService.ExistAsync(request.Name))
            {
                ModelState.AddModelError("Name", "Social with this name already exists");
                return BadRequest(ModelState);
            }

            await _socialService.CreateAsync(request);

            return CreatedAtAction(nameof(Create), request);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Edit([FromRoute] int id, [FromForm] SocialEditDto request)
        {
            if (await _socialService.ExistExceptByIdAsync(id, request.Name))
            {
                ModelState.AddModelError("Name", "Social with this name already exists");
                return BadRequest(ModelState);
            }

            await _socialService.EditAsync(id, request);

            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> Delete([FromQuery] int? id)
        {
            if (id == null) return BadRequest();

            await _socialService.DeleteAsync((int)id);

            return Ok();
        }
    }
}
