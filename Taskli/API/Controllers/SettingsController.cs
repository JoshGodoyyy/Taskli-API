using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Taskli.Application.DTOs;
using Taskli.Domain.Entities;
using Taskli.Infrastructure.Data;

namespace Taskli.API.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class SettingsController : Controller {
    private readonly AppDbContext _context;

    public SettingsController(AppDbContext context) => _context = context;

    [HttpGet]
    public async Task<IActionResult> Get() {
        var settings = await _context.Settings.FirstOrDefaultAsync();
        if (settings == null) {
            return NotFound();
        }

        return Ok(settings);
    }

    [HttpPost]
    public async Task<IActionResult> Update([FromBody]List<RequirementResult> data) {
        var settings = await _context.Settings.FirstOrDefaultAsync();

        if (settings == null) {
            return NotFound();
        }

        settings.TaskRequiredFields = data;

        await _context.SaveChangesAsync();

        return Ok();
    }
}
