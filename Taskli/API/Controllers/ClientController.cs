using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;
using Taskli.Application.DTOs;
using Taskli.Domain.Entities;
using Taskli.Infrastructure.Data;

namespace Taskli.API.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class ClientController : Controller {
    private readonly AppDbContext _context;

    public ClientController(AppDbContext context) => _context = context;

    [HttpGet]
    public async Task<IActionResult> GetAll() {
        var clients = await _context.Clients.AsNoTracking().ToListAsync();
        return Ok(clients);
    }

    [HttpPost]
    public async Task<IActionResult> Update([FromBody] ClientUpdate dto) {
        var client = await _context.Clients.FirstOrDefaultAsync(c => c.Id == dto.ClientId);

        if (client == default) {
            return NotFound();
        }

        foreach (var field in dto.Data) {
            var prop = typeof(ClientEntity).GetProperty(field.Name);
            if (prop == null || field.Value == null) continue;

            object value = field.Value;

            if (value is JsonElement jsonElement) {
                value = jsonElement.Deserialize(prop.PropertyType)!;
                prop.SetValue(client, value);
                continue;
            }

            var targetType = Nullable.GetUnderlyingType(prop.PropertyType)
                             ?? prop.PropertyType;

            if (targetType.IsEnum) {
                var stringValue = value?.ToString();

                if (!string.IsNullOrWhiteSpace(stringValue) &&
                    Enum.TryParse(targetType, stringValue, true, out var enumValue)) {
                    prop.SetValue(client, enumValue);
                }

                continue;
            } else {
                prop.SetValue(client, Convert.ChangeType(value, targetType));
            }
        }

        await _context.SaveChangesAsync();

        return Ok();
    }

    //[HttpPost("Get")]
    //public async Task<IActionResult> GetClient([FromBody] SearchClient dto) {

    //}
}
