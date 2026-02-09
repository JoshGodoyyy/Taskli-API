namespace Taskli.Application.DTOs;

public class AttachmentUpload {
    public int TaskId { get; set; }
    public required IFormFile File { get; set; }
    public required string MimeType { get; set; }
}
