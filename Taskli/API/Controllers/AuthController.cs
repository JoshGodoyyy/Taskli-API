using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Taskli.Application.DTOs;
using Taskli.Application.Services;

namespace Taskli.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController : Controller {
    private readonly AuthService _authService;

    public AuthController(AuthService authService) {
        _authService = authService;
    }

    [AllowAnonymous]
    [HttpPost("login")]
    public IActionResult Login([FromBody] LoginRequest request) {
        var token = _authService.Login(request.Username, request.Password);
        if (token == null) {
            return Unauthorized(new { message = "Usuário e/ou senha inválido(s)." });
        }
        return Ok(new { token });
    }
}
