using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Taskli.Infrastructure.Data;

namespace Taskli.API.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class SalesTableController : Controller {
    private readonly AppDbContext _context;

    public SalesTableController(AppDbContext context) => _context = context;

    [HttpGet]
    public async Task<IActionResult> GetAll() {
        var salesTables = await _context
                                    .SalesTables
                                    .AsNoTracking()
                                    .ToListAsync();

        return Ok(salesTables);
    }
}
