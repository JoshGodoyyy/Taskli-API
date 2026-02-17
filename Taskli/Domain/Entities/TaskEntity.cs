namespace Taskli.Domain.Entities;

public class TaskEntity {
    public int Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public bool AffectsDeadline { get; set; } = false;
    public int CreatorId { get; set; }
    public int AssignedUserId { get; set; }
    public string ExecutionStreet { get; set; } = string.Empty;
    public string? ExecutionNumber { get; set; }
    public string? ExecutionComplement { get; set; }
    public string ExecutionNeighborhood { get; set; } = string.Empty;
    public string ExecutionCity { get; set; } = string.Empty;
    public string ExecutionState { get; set; } = string.Empty;
    public string? ExecutionZipCode { get; set; }
    public double? Latitude { get; set; }
    public double? Longitude { get; set; }
    public int ClientId { get; set; }
    public ClientEntity? Client { get; set; }
    public bool Finished { get; set; }
    public bool InProgress { get; set; }
    public string? Justification { get; set; }
    public ICollection<TaskLogEntity> TaskLogs { get; set; } = [];
    public ICollection<AttachmentEntity> Attachments { get; set; } = [];
    public ICollection<MessageEntity> Messages { get; set; } = [];
}
