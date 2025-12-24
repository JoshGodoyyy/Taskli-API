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
    public double? Latitude { get; set; }
    public double? Longitude { get; set; }
    public int ClientId { get; set; }
    public ClientEntity? Client { get; set; }
    public bool Finished { get; set; }
    public ICollection<TaskLogEntity> TaskLogs { get; set; } = [];
}
