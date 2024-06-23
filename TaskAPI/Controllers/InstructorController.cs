using Microsoft.AspNetCore.Mvc;
using TaskAPI.Services.Interfaces;

namespace TaskAPI.Controllers
{
    public class InstructorController : BaseController
    {
        private readonly IInstructorService _instructorService;

        public InstructorController(IInstructorService instructorService)
        {
            _instructorService = instructorService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllWithSocials()
        {
            return Ok(await _instructorService.GetAllWithSocialsAsync());
        }
    }
}
