using Microsoft.EntityFrameworkCore;
using Taskli.Domain.Entities;

namespace Taskli.Infrastructure.Data;

public class AppDbContext : DbContext {
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options) {
    }

    public DbSet<UserEntity> Users => Set<UserEntity>();
    public DbSet<ClientEntity> Clients => Set<ClientEntity>();
    public DbSet<TaskEntity> Tasks => Set<TaskEntity>();
    public DbSet<TaskLogEntity> TaskLogs => Set<TaskLogEntity>();
    public DbSet<AttachmentEntity> Attachments => Set<AttachmentEntity>();
    public DbSet<MessageEntity> Messages => Set<MessageEntity>();

    protected override void OnModelCreating(ModelBuilder modelBuilder) {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
    }
}
