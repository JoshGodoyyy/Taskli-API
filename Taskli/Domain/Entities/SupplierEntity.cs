namespace Taskli.Domain.Entities;

public class SupplierEntity {
    public int Id { get; set; }
    public string TradeName { get; set; } = string.Empty;
    public string CorporateName { get; set; } = string.Empty;
    public string? CNPJ { get; set; } = string.Empty;
}
