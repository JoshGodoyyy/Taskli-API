using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Taskli.Infrastructure.Data;

namespace Taskli.API.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class DeliverySectorController : Controller {
    private readonly AppDbContext _context;

    public DeliverySectorController(AppDbContext context) => _context = context;

    [HttpGet]
    public async Task<IActionResult> GetAll() {
        var sectors = await _context
                                    .DeliverySectors
                                    .AsNoTracking()
                                    .ToListAsync();

        return Ok(sectors);
    }
}
