using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Taskli.Infrastructure.Data;

namespace Taskli.API.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class PaymentMethodController : Controller {
    private readonly AppDbContext _context;

    public PaymentMethodController(AppDbContext context) => _context = context;

    [HttpGet]
    public async Task<IActionResult> GetAll() {
        var paymentMethods = await _context
                                    .PaymentMethods
                                    .AsNoTracking()
                                    .ToListAsync();
        return Ok(paymentMethods);
    }
}
