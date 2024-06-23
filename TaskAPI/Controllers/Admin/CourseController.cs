using Microsoft.AspNetCore.Mvc;
using TaskAPI.DTOs.Courses;
using TaskAPI.Services.Interfaces;

namespace TaskAPI.Controllers.Admin
{
    public class CourseController : BaseController
    {
        private readonly ICourseService _courseService;

        public CourseController(ICourseService courseService)
        {
            _courseService = courseService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _courseService.GetAllAsync());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Detail([FromRoute] int id)
        {
            var course = await _courseService.GetByIdDetailAsync(id);

            if (course is null) return NotFound();

            return Ok(course);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromForm] CourseCreateDto request)
        {
            if (await _courseService.ExistAsync(request.Name))
            {
                ModelState.AddModelError("Name", "Course with this name already exists");
                return BadRequest(ModelState);
            }

            await _courseService.CreateAsync(request);

            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Edit([FromRoute] int id, [FromForm] CourseEditDto request)
        {
            if (await _courseService.ExistExceptByIdAsync(id, request.Name))
            {
                ModelState.AddModelError("Name", "Course with this name already exists");
                return BadRequest(ModelState);
            }

            await _courseService.EditAsync(id, request);

            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> Delete([FromQuery] int? id)
        {
            if (id == null) return BadRequest();

            await _courseService.DeleteAsync((int)id);

            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> SetMainImage([FromBody] MainAndDeleteImageDto request)
        {
            await _courseService.SetMainImageAsync(request);
            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> DeleteImage([FromBody] MainAndDeleteImageDto request)
        {
            await _courseService.DeleteCourseImageAsync(request);
            return Ok();
        }
    }
}
