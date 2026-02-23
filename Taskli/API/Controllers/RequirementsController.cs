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

        if (underlyingType == typeof(int)) return "int";
        if (underlyingType == typeof(string)) return "string";
        if (underlyingType == typeof(decimal)) return "decimal";
        if (underlyingType == typeof(DateTime)) return "date";
        if (underlyingType == typeof(bool)) return "bool";

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
            }).OrderBy(item => item.Description);

        return Ok(fields);
    }
}
