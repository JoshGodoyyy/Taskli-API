using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Taskli.Application.DTOs;
using Taskli.Domain.Entities;
using Taskli.Infrastructure.Data;

namespace Taskli.API.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class AttachmentController : Controller {
    private readonly AppDbContext _context;

    public AttachmentController(AppDbContext context) => _context = context;

    [HttpPost("Get")]
    public async Task<IActionResult> Get([FromBody] AttachmentRequest request) {
        var attachments = await _context.Attachments
                                        .Where(a => a.TaskId == request.Id)
                                        .ToListAsync();

        return Ok(attachments);
    }

    [HttpPost("Add")]
    public async Task<IActionResult> Add([FromForm] AttachmentUpload dto) {
        using var ms = new MemoryStream();
        await dto.File.CopyToAsync(ms);

        var attachment = new AttachmentEntity {
            TaskId = dto.TaskId,
            File = ms.ToArray(),
            MimeType = dto.MimeType,
        };

        _context.Attachments.Add(attachment);

        await _context.SaveChangesAsync();
        return Ok(attachment);
    }

    [HttpDelete]
    public async Task<IActionResult> Delete([FromBody] AttachmentRequest request) {
        var attachment = await _context.Attachments
                                       .FirstOrDefaultAsync(a => a.Id == request.Id);
        if (attachment == null) {
            return NotFound();
        }

        _context.Attachments.Remove(attachment);
        await _context.SaveChangesAsync();
        return NoContent();
    }
}
