namespace Taskli.Domain.Entities;

public class TaskLogEntity {
    public int Id { get; set; }
    public int TaskId { get; set; }
    public TaskEntity? Task { get; set; }
    public DateTime Start { get; set; }
    public DateTime? End { get; set; }
}
