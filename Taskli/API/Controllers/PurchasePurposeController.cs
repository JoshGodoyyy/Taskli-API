using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Taskli.Infrastructure.Data;

namespace Taskli.API.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class PurchasePurposeController : Controller {
    private readonly AppDbContext _context;

    public PurchasePurposeController(AppDbContext context) => _context = context;

    [HttpGet]
    public async Task<IActionResult> GetAll() {
        var purposes = await _context.PurchasePurposes
                               .AsNoTracking()
                               .ToListAsync();

        return Ok(purposes);
    }
}
