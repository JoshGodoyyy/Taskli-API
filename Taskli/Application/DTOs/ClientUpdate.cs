namespace Taskli.Application.DTOs;

public class ClientUpdate {
    public int ClientId { get; set; }
    public required List<FieldData> Data { get; set; }
}
