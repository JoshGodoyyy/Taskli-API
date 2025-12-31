namespace Taskli.Domain.Entities;

public class AttachmentEntity {
    public int Id { get; set; }
    public int TaskId { get; set; }
    public TaskEntity? Task { get; set; }
    public required byte[] File { get; set; }
}
