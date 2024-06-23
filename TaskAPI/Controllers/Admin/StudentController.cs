using Microsoft.AspNetCore.Mvc;
using TaskAPI.DTOs.Courses;
using TaskAPI.DTOs.Students;
using TaskAPI.Services.Interfaces;

namespace TaskAPI.Controllers.Admin
{
    public class StudentController : BaseController
    {
        private readonly IStudentService _studentService;

        public StudentController(IStudentService studentService)
        {
            _studentService = studentService;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Detail([FromRoute] int id)
        {
            var student = await _studentService.GetByIdDetailAsync(id);

            if (student == null) return NotFound();

            return Ok(student);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromForm] StudentCreateDto request)
        {
            await _studentService.CreateAsync(request);

            return CreatedAtAction(nameof(Create), request);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Edit([FromRoute] int id, [FromForm] StudentEditDto request)
        {
            await _studentService.EditAsync(id, request);

            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> Delete([FromQuery] int? id)
        {
            if (id == null) return BadRequest();

            await _studentService.DeleteAsync((int)id);

            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> AddCourse([FromBody] CourseStudentAddDto request)
        {
            await _studentService.AddCourseAsync(request);

            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> DeleteCourse([FromQuery] int? courseStudentId)
        {
            if (courseStudentId is null) return BadRequest();

            await _studentService.DeleteCourseAsync((int)courseStudentId);

            return Ok();
        }
    }
}
