using Taskli.Application.DTOs;

namespace Taskli.Domain.Entities;

public class SettingsEntity {
    public int Id { get; set; }
    public int MinDistanceToExecute { get; set; }
    public List<RequirementResult>? TaskRequiredFields { get; set; }
}
