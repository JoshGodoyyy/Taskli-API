using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Taskli.Infrastructure.Data;

namespace Taskli.API.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class SettingsController : Controller {
    private readonly AppDbContext _context;

    public SettingsController(AppDbContext context) => _context = context;

    [HttpGet]
    public IActionResult Get() {
        var settings = _context.Settings.FirstOrDefault();
        if (settings == null) {
            return NotFound();
        }
        return Ok(settings);
    }
}
