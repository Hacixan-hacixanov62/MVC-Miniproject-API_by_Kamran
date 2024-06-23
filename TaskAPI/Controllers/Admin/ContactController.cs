using Microsoft.AspNetCore.Mvc;
using TaskAPI.DTOs.Contacts;
using TaskAPI.Services.Interfaces;

namespace TaskAPI.Controllers.Admin
{
    public class ContactController : BaseController
    {
        private readonly IContactService _contactService;

        public ContactController(IContactService contactService)
        {
            _contactService = contactService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _contactService.GetAllAsync());
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] ContactCreateDto request)
        {
            await _contactService.CreateAsync(request);

            return CreatedAtAction(nameof(Create), request);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete([FromQuery] int? id)
        {
            if (id is null) return BadRequest();

            await _contactService.DeleteAsync((int)id);

            return Ok();
        }
    }
}
