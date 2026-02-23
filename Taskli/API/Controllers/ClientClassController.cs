using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Taskli.Infrastructure.Data;

namespace Taskli.API.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class ClientClassController : Controller {
    private readonly AppDbContext _context;

    public ClientClassController(AppDbContext context) => _context = context;

    [HttpGet]
    public async Task<IActionResult> GetAll() {
        var clientClasses = await _context
                                    .ClientClasses
                                    .AsNoTracking()
                                    .ToListAsync();
        return Ok(clientClasses);
    }
}
