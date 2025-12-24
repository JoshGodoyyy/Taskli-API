using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Taskli.Application.DTOs;
using Taskli.Domain.Entities;
using Taskli.Infrastructure.Data;

namespace Taskli.Application.Services;

public class AuthService {
    private readonly AppDbContext _context;
    private readonly IConfiguration _configuration;
    private readonly PasswordHasher<UserEntity> _passwordHasher;

    public AuthService(AppDbContext context, IConfiguration configuration) {
        _context = context;
        _configuration = configuration;
        _passwordHasher = new PasswordHasher<UserEntity>();
    }

    public LoginResult? Login(string username, string password) {
        var user = _context.Users.FirstOrDefault(u => u.Name == username);

        if (user == null) {
            return null;
        }

        if (user.Password != password) {
            return null;
        }

        var token = GenerateToken(user);

        return new LoginResult {
            Id = user.Id,
            Username = user.Name,
            Token = token,
        };
    }

    private string GenerateToken(UserEntity user) {
        var jwt = _configuration.GetSection("jwt");

        var claims = new List<Claim> {
            new(ClaimTypes.NameIdentifier, user.Id.ToString()),
            new(ClaimTypes.Name, user.Name)
        };

        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwt["TASKLIKEY"]!));

        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        var token = new JwtSecurityToken(
            issuer: jwt["TASKLIISSUER"],
            audience: jwt["TASKLIAUDIENCE"],
            claims: claims,
            expires: DateTime.UtcNow.AddDays(30),
            signingCredentials: creds
        );

        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}
