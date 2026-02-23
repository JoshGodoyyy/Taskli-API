using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Taskli.Infrastructure.Data;

namespace Taskli.API.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class AccountingPlanController : Controller {
    private readonly AppDbContext _context;

    public AccountingPlanController(AppDbContext context) => _context = context;

    [HttpGet]
    public async Task<IActionResult> GetAll() {
        var accounts = await _context.AccountingPlans
                                .AsNoTracking()
                                .ToListAsync();
        return Ok(accounts);
    }
}
