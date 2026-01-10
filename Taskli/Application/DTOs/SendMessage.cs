namespace Taskli.Application.DTOs;

public class SendMessage {
    public int TaskId { get; set; }
    public int SenderId { get; set; }
    public string Text { get; set; } = string.Empty;
}
