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
public class TaskController : Controller {
    private readonly AppDbContext _context;

    public TaskController(AppDbContext context) {
        _context = context;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll() {
        var tasks = await _context.Tasks
                                  .AsNoTracking()
                                  .Select(t => new TaskResult {
                                      Id = t.Id,
                                      Title = t.Title,
                                      Description = t.Description,
                                      StartDate = t.StartDate,
                                      EndDate = t.EndDate,
                                      ExecutionStreet = t.ExecutionStreet,
                                      ExecutionNumber = t.ExecutionNumber,
                                      ExecutionComplement = t.ExecutionComplement,
                                      ExecutionNeighborhood = t.ExecutionNeighborhood,
                                      ExecutionCity = t.ExecutionCity,
                                      ExecutionState = t.ExecutionState,
                                      ExecutionZipCode = t.ExecutionZipCode,
                                      Latitude = t.Latitude,
                                      Longitude = t.Longitude,
                                      Client = new ClientResult {
                                          Id = t.Client!.Id,
                                          TradeName = t.Client.TradeName,
                                      },
                                      Finished = t.Finished,
                                      InProgress = t.InProgress
                                  })
                                  .ToListAsync();
        return Ok(tasks);
    }

    [HttpPost("Get")]
    public async Task<IActionResult> GetTask([FromBody] TaskRequest request) {
        var task = await _context.Tasks
                           .AsNoTracking()
                           .Where(t => t.Id == request.Id)
                           .Select(t => new TaskResult {
                               Id = t.Id,
                               Title = t.Title,
                               Description = t.Description,
                               StartDate = t.StartDate,
                               EndDate = t.EndDate,
                               ExecutionStreet = t.ExecutionStreet,
                               ExecutionNumber = t.ExecutionNumber,
                               ExecutionComplement = t.ExecutionComplement,
                               ExecutionNeighborhood = t.ExecutionNeighborhood,
                               ExecutionCity = t.ExecutionCity,
                               ExecutionState = t.ExecutionState,
                               ExecutionZipCode = t.ExecutionZipCode,
                               Latitude = t.Latitude,
                               Longitude = t.Longitude,
                               Client = new ClientResult {
                                   Id = t.Client!.Id,
                                   TradeName = t.Client.TradeName,
                               },
                               Finished = t.Finished,
                               InProgress = t.InProgress
                           })
                           .FirstOrDefaultAsync();

        if (task == null)
            return NotFound();

        return Ok(task);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] TaskEntity task) {
        _context.Tasks.Add(task);
        await _context.SaveChangesAsync();
        return CreatedAtAction(nameof(GetAll), new { id = task.Id }, task);
    }

    [HttpPost("Localization")]
    public async Task<IActionResult> SetLocalization([FromBody] TaskUpdateRequest task) {
        var result = await _context.Tasks
                                   .FirstOrDefaultAsync(t => t.Id == task.Id);

        if (result == null)
            return NotFound();

        result.Latitude = task.Latitude;
        result.Longitude = task.Longitude;

        await _context.SaveChangesAsync();

        return Ok(task.Id);
    }

    [HttpPost("Start")]
    public async Task<IActionResult> StartTask([FromBody] TaskUpdateRequest task) {
        var result = await _context.Tasks
                                   .FirstOrDefaultAsync(t => t.Id == task.Id);

        if (result == null)
            return NotFound();

        result.InProgress = true;

        await _context.SaveChangesAsync();

        return Ok(task.Id);
    }

    [HttpPost("Pause")]
    public async Task<IActionResult> PauseTask([FromBody] TaskUpdateRequest task) {
        var result = await _context.Tasks
                                   .FirstOrDefaultAsync(t => t.Id == task.Id);

        if (result == null)
            return NotFound();

        result.InProgress = false;

        await _context.SaveChangesAsync();

        return Ok(task.Id);
    }

    [HttpPost("Finish")]
    public async Task<IActionResult> FinishTask([FromBody] TaskUpdateRequest task) {
        var result = await _context.Tasks
                                   .FirstOrDefaultAsync(t => t.Id == task.Id);

        if (result == null)
            return NotFound();

        result.InProgress = false;
        result.Finished = true;

        await _context.SaveChangesAsync();

        return Ok(task.Id);
    }
}
