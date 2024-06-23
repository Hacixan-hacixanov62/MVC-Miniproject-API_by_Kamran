using Microsoft.AspNetCore.Mvc;
using TaskAPI.Services.Interfaces;

namespace TaskAPI.Controllers
{
    public class CourseController : BaseController
    {
        private readonly ICourseService _courseService;

        public CourseController(ICourseService courseService)
        {
            _courseService = courseService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllPopular()
        {
            return Ok(await _courseService.GetAllPopularAsync());
        }
    }
}
