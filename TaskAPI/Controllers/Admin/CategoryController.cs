using Microsoft.AspNetCore.Mvc;
using TaskAPI.DTOs.Categories;
using TaskAPI.Services.Interfaces;

namespace TaskAPI.Controllers.Admin
{
    public class CategoryController : BaseController
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Detail([FromRoute] int id)
        {
            var category = await _categoryService.GetByIdDetailAsync(id);

            if (category == null) return NotFound();

            return Ok(category);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromForm] CategoryCreateDto request)
        {
            if (await _categoryService.ExistAsync(request.Name))
            {
                ModelState.AddModelError("Name", "Category with this name already exists");
                return BadRequest(ModelState);
            }

            await _categoryService.CreateAsync(request);

            return CreatedAtAction(nameof(Create), request);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Edit([FromRoute] int id, [FromForm] CategoryEditDto request)
        {
            if (await _categoryService.ExistExceptByIdAsync(id, request.Name))
            {
                ModelState.AddModelError("Name", "Category with this name already exists");
                return BadRequest(ModelState);
            }

            await _categoryService.EditAsync(id, request);

            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> Delete([FromQuery] int? id)
        {
            if (id == null) return BadRequest();

            await _categoryService.DeleteAsync((int)id);

            return Ok();
        }
    }
}
