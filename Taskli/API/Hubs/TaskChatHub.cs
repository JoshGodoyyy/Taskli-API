using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;

namespace Taskli.API.Hubs;

[Authorize]
public class TaskChatHub : Hub {
    public async Task JoinTask(int taskId)
        => await Groups.AddToGroupAsync(
            Context.ConnectionId,
            $"task-{taskId}"
        );

    public async Task LeaveTask(int taskId)
        => await Groups.RemoveFromGroupAsync(
            Context.ConnectionId,
            $"task-{taskId}"
        );
}
