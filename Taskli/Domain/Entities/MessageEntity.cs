namespace Taskli.Domain.Entities;

public class MessageEntity {
    public int Id { get; set; }
    public int TaskId { get; set; }
    public TaskEntity? Task { get; set; }
    public int SenderId { get; set; }
    public UserEntity? Sender { get; set; }
    public string Text { get; set; } = string.Empty;
    public DateTime SendedAt { get; set; }
}
