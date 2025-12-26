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
public class TaskLogController : Controller {
    private readonly AppDbContext _context;

    public TaskLogController(AppDbContext context) {
        _context = context;
    }

    [HttpPost("Get")]
    public async Task<IActionResult> GetTaskLogs([FromBody] TaskLogRequest request) {
        var taskLogs = await _context.TaskLogs
                                     .AsNoTracking()
                                     .Select(t => new TaskLogResult {
                                         TaskId = t.TaskId,
                                         Start = t.Start,
                                         End = t.End
                                     })
                                     .Where(t => t.TaskId == request.Id)
                                     .ToListAsync();
        return Ok(taskLogs);
    }

    [HttpPost("Start")]
    public async Task<IActionResult> Start([FromBody] TaskLogRequest request) {
        var log = new TaskLogEntity() {
            TaskId = request.Id,
            Start = DateTime.Now
        };

        _context.TaskLogs.Add(log);

        await _context.SaveChangesAsync();

        return Ok(log);
    }

    [HttpPost("End")]
    public async Task<IActionResult> End([FromBody] TaskLogRequest request) {
        var log = await _context.TaskLogs
                                .Where(l => l.TaskId == request.Id && l.End == null)
                                .OrderByDescending(l => l.Id)
                                .FirstOrDefaultAsync();

        if (log == null)
            return NotFound();

        log.End = DateTime.Now;

        await _context.SaveChangesAsync();

        return Ok();
    }
}
