using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Taskli.Infrastructure.Data;

namespace Taskli.API.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class SupplierController : Controller {
    private readonly AppDbContext _context;

    public SupplierController(AppDbContext context) => _context = context;

    [HttpGet]
    public async Task<IActionResult> GetAll() {
        var suppliers = await _context
                                .Suppliers
                                .AsNoTracking()
                                .Where(s => s.ClassId == 90)
                                .ToListAsync();

        return Ok(suppliers);
    }
}
