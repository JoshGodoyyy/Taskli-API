using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Taskli.Application.DTOs;
using Taskli.Infrastructure.Data;

namespace Taskli.API.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class RequirementsController : Controller {
    private readonly AppDbContext _context;

    public RequirementsController(AppDbContext context) => _context = context;

    private static string GetFriendlyTypeName(Type type) {
        var underlyingType = Nullable.GetUnderlyingType(type) ?? type;

        if (underlyingType == typeof(int)) return "Inteiro";
        if (underlyingType == typeof(string)) return "Texto";
        if (underlyingType == typeof(decimal)) return "Decimal";
        if (underlyingType == typeof(DateTime)) return "Data";
        if (underlyingType == typeof(bool)) return "Booleano";

        return underlyingType.Name;
    }

    private static bool IsNullable(Type type) {
        return Nullable.GetUnderlyingType(type) != null || !type.IsValueType;
    }

    [HttpGet]
    public async Task<IActionResult> GetRequirements() {
        var fields = typeof(SelectClientField)
            .GetProperties()
            .Select(p => new RequirementResult {
                Description = p.Name,
                Type = GetFriendlyTypeName(p.PropertyType),
                Nullable = IsNullable(p.PropertyType)
            });

        return Ok(fields);
    }
}
