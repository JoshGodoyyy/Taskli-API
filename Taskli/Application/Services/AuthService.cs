using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
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

    public string? Login(string username, string password) {
        var user = _context.Users.FirstOrDefault(u => u.Name == username);

        if (user == null) {
            return null;
        }

        if (user.Password != password) {
            return null;
        }

        return GenerateToken(user);
    }

    private string GenerateToken(UserEntity user) {
        var jwt = _configuration.GetSection("jwt");

        var claims = new List<Claim> {
            new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
            new Claim(ClaimTypes.Name, user.Name)
        };

        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwt["key"]!));

        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        var token = new JwtSecurityToken(
            issuer: jwt["Issuer"],
            audience: jwt["Audience"],
            claims: claims,
            expires: DateTime.UtcNow.AddMinutes(int.Parse(jwt["ExpireMinutes"]!)),
            signingCredentials: creds
        );

        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}
