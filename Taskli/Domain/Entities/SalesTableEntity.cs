namespace Taskli.Domain.Entities;

public class SalesTableEntity {
    public int Id { get; set; }
    public int InternalTableId { get; set; }
    public string Description { get; set; } = string.Empty;
    public bool Inactive { get; set; }
}
