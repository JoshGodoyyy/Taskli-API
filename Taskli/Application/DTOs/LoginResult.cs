namespace Taskli.Application.DTOs;

public class LoginResult {
    public int Id { get; set; }
    public required string Username { get; set; }
    public required string Token { get; set; }
}
