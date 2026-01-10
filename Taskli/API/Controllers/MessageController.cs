using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using Taskli.API.Hubs;
using Taskli.Application.DTOs;
using Taskli.Domain.Entities;
using Taskli.Infrastructure.Data;

namespace Taskli.API.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class MessageController : Controller {
    private readonly AppDbContext _context;
    private readonly IHubContext<TaskChatHub> _hub;

    public MessageController(
        AppDbContext context,
        IHubContext<TaskChatHub> hub
    ) {
        _context = context;
        _hub = hub;
    }

    [HttpPost]
    public async Task<IActionResult> GetMessages(int taskId) {
        var messages = await _context.Messages
            .Where(x => x.TaskId == taskId)
            .OrderBy(x => x.SenderId)
            .Select(x => new {
                x.Id,
                x.Text,
                x.TaskId,
                x.SenderId,
                x.SendedAt
            })
            .ToListAsync();

        return Ok(messages);
    }

    [HttpPost("send")]
    public async Task<IActionResult> SendMessage([FromBody] SendMessage dto) {
        var message = new MessageEntity {
            TaskId = dto.TaskId,
            SenderId = dto.SenderId,
            Text = dto.Text,
            SendedAt = DateTime.Now,
        };

        _context.Messages.Add(message);

        await _context.SaveChangesAsync();

        await _hub.Clients
            .Group($"task-{dto.TaskId}")
            .SendAsync("ReceiveMessage", new {
                message.Id,
                message.TaskId,
                message.SenderId,
                message.Text,
                message.SendedAt
            });

        return Ok();
    }
}
