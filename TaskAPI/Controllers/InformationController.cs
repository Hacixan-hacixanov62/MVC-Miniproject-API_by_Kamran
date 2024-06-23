using Microsoft.AspNetCore.Mvc;
using TaskAPI.Services.Interfaces;

namespace TaskAPI.Controllers
{
    public class InformationController : BaseController
    {
        private readonly IInformationService _informationService;

        public InformationController(IInformationService informationService)
        {
            _informationService = informationService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _informationService.GetAllAsync());
        }
    }
}
