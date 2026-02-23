using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Taskli.Infrastructure.Data;

namespace Taskli.API.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class CustomerReferralController : Controller {
    private readonly AppDbContext _context;

    public CustomerReferralController(AppDbContext context) => _context = context;

    [HttpGet]
    public async Task<IActionResult> GetAll() {
        var referrals = await _context.CustomerReferrals
                                .AsNoTracking()
                                .ToListAsync();
        return Ok(referrals);
    }
}
