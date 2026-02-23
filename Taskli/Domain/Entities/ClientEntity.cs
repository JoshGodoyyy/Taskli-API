using Taskli.Domain.Enums;

namespace Taskli.Domain.Entities;

public class ClientEntity {
    public int Id { get; set; }
    public string? TradeName { get; set; }
    public string? CorporateName { get; set; }
    public EPersonType PersonType { get; set; }
    public string? CNPJ { get; set; } = string.Empty;
    public string IE { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Phone { get; set; } = string.Empty;
    public string Address { get; set; } = string.Empty;
    public string Number { get; set; } = string.Empty;
    public string Complement { get; set; } = string.Empty;
    public string Neighborhood { get; set; } = string.Empty;
    public string City { get; set; } = string.Empty;
    public string State { get; set; } = string.Empty;
    public string CEP { get; set; } = string.Empty;
    public ICollection<TaskEntity> Tasks { get; set; } = [];
}
