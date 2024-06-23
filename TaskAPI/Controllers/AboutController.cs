using Microsoft.AspNetCore.Mvc;
using TaskAPI.Services.Interfaces;

namespace TaskAPI.Controllers
{
    public class AboutController : BaseController
    {
        private readonly IAboutService _aboutService;

        public AboutController(IAboutService aboutService)
        {
            _aboutService = aboutService;
        }

        [HttpGet]
        public async Task<IActionResult> GetFirst()
        {
            return Ok(await _aboutService.GetFirstAsync());
        }
    }
}
