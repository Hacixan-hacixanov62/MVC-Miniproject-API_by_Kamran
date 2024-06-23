using Microsoft.AspNetCore.Mvc;
using TaskAPI.DTOs.Settings;
using TaskAPI.Services.Interfaces;

namespace TaskAPI.Controllers.Admin
{
    public class SettingController : BaseController
    {
        private readonly ISettingService _settingService;

        public SettingController(ISettingService settingService)
        {
            _settingService = settingService;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Edit([FromRoute] int id, [FromBody] SettingEditDto request)
        {
            await _settingService.EditAsync(id, request);

            return Ok();
        }
    }
}
