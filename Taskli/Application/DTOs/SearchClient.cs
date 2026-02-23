namespace Taskli.Application.DTOs;

public class SearchClient {
    public int Id { get; set; }
    public required List<string> Fields { get; set; }
}
