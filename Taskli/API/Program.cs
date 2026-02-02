using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Taskli.API.Hubs;
using Taskli.Application.Services;
using Taskli.Infrastructure.Data;

var builder = WebApplication.CreateBuilder(args);

builder.WebHost.UseUrls("http://*:8080");

builder.Services.Configure<FormOptions>(options => {
    options.MultipartBodyLengthLimit = 50 * 1024 * 1024;
});

builder.Services.AddDbContext<AppDbContext>(options => {
    options.UseMySql(
        builder.Configuration.GetConnectionString("TASKLIDefault"),
        ServerVersion.AutoDetect(
            builder.Configuration.GetConnectionString("TASKLIDefault"))
        );
});

var jwtSettings = builder.Configuration.GetSection("Jwt");

builder.Services.AddAuthentication(options => {
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
    .AddJwtBearer(options => {
        options.TokenValidationParameters = new TokenValidationParameters {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,

            ValidIssuer = jwtSettings["TASKLIISSUER"],
            ValidAudience = jwtSettings["TASKLIAUDIENCE"],
            IssuerSigningKey = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(jwtSettings["TASKLIKEY"]!)),
            ClockSkew = TimeSpan.Zero
        };
    });

builder.Services.AddAuthorization();

builder.Services.AddScoped<AuthService>();

builder.Services.AddSignalR();

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment()) {
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.MapHub<TaskChatHub>("/hubs/taskchat");

app.Run();
