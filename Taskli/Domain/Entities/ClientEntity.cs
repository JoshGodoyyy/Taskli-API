using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using Taskli.Domain.Enums;

namespace Taskli.Domain.Entities;

public class ClientEntity {
    public int Id { get; set; }
    public string? TradeName { get; set; }
    public string? CorporateName { get; set; }
    public EPersonType PersonType { get; set; }
    public string CNPJ { get; set; } = string.Empty;
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

    // Fields for Reflection
    [JsonIgnore] public string? Fantasia { get; set; }
    [JsonIgnore] public string? RazaoSocial { get; set; }
    [JsonIgnore] public string? TipoPessoa { get; set; }
    [JsonIgnore] public string? Cnpj { get; set; }
    [JsonIgnore] public string? Ie { get; set; }
    [JsonIgnore] public string? End_nomerua { get; set; }
    [JsonIgnore] public string? End_numero { get; set; }
    [JsonIgnore] public string? End_cep { get; set; }
    [JsonIgnore] public string? End_complemento { get; set; }
    [JsonIgnore] public string? End_bairro { get; set; }
    [JsonIgnore] public string? End_cidade { get; set; }
    [JsonIgnore] public string? End_estado { get; set; }
    [JsonIgnore] public string? Site { get; set; }
    [JsonIgnore] public string? Telefone { get; set; }
    [JsonIgnore] public string? Fax { get; set; }
    [JsonIgnore] public string? End_logradouro { get; set; }
    [JsonIgnore] public string? Observacoes { get; set; }
    [JsonIgnore] public string? ObservacoesPrivada { get; set; }
    [JsonIgnore] public int? IdVendedor { get; set; }
    [JsonIgnore] public decimal? Comissao { get; set; }
    [JsonIgnore] public int? IdTabela { get; set; }
    [JsonIgnore] public int? IdClasse { get; set; }
    [JsonIgnore] public string? Ent_cnpj { get; set; }
    [JsonIgnore] public string? Ent_nomeRua { get; set; }
    [JsonIgnore] public string? Ent_numero { get; set; }
    [JsonIgnore] public string? Ent_cep { get; set; }
    [JsonIgnore] public string? Ent_complemento { get; set; }
    [JsonIgnore] public string? Ent_bairro { get; set; }
    [JsonIgnore] public string? Ent_cidade { get; set; }
    [JsonIgnore] public string? Ent_estado { get; set; }
    [JsonIgnore] public string? Ent_logradouro { get; set; }
    [JsonIgnore] public int? IdSetor { get; set; }
    [JsonIgnore] public string? Ent_email { get; set; }
    [JsonIgnore] public string? Cob_logradouro { get; set; }
    [JsonIgnore] public string? Cob_nomeRua { get; set; }
    [JsonIgnore] public string? Cob_numero { get; set; }
    [JsonIgnore] public string? Cob_cep { get; set; }
    [JsonIgnore] public string? Cob_complemento { get; set; }
    [JsonIgnore] public string? Cob_bairro { get; set; }
    [JsonIgnore] public string? Cob_cidade { get; set; }
    [JsonIgnore] public string? Cob_estado { get; set; }
    [JsonIgnore] public string? Cob_alertaVendas { get; set; }
    [JsonIgnore] public string? Cob_observacoes { get; set; }
    [JsonIgnore] public string? Cob_email { get; set; }
    [JsonIgnore] public decimal? Limite { get; set; }
    [JsonIgnore] public string? Serasa { get; set; }
    [JsonIgnore] public DateTime? DataFundacao { get; set; }
    [JsonIgnore] public DateTime? DataCadastro { get; set; }
    [JsonIgnore] public DateTime? DataAtualizacao { get; set; }
    [JsonIgnore] public DateTime? DataUltimaCompra { get; set; }
    [JsonIgnore] public DateTime? DataConsultaSerasa { get; set; }
    [JsonIgnore] public string? RE1Nome { get; set; }
    [JsonIgnore] public string? RE1cpf { get; set; }
    [JsonIgnore] public string? RE1rg { get; set; }
    [JsonIgnore] public DateTime? RE1Nascimento { get; set; }
    [JsonIgnore] public decimal? RE1Quota { get; set; }
    [JsonIgnore] public string? RE2Nome { get; set; }
    [JsonIgnore] public string? RE2cpf { get; set; }
    [JsonIgnore] public string? RE2rg { get; set; }
    [JsonIgnore] public DateTime? RE2Nascimento { get; set; }
    [JsonIgnore] public decimal? RE2Quota { get; set; }
    [JsonIgnore] public string? RE3Nome { get; set; }
    [JsonIgnore] public string? RE3cpf { get; set; }
    [JsonIgnore] public string? RE3rg { get; set; }
    [JsonIgnore] public DateTime? RE3Nascimento { get; set; }
    [JsonIgnore] public decimal? RE3Quota { get; set; }
    [JsonIgnore] public decimal? CapitalSocial { get; set; }
    [JsonIgnore] public int? StatusAtivo { get; set; }
    [JsonIgnore] public int? IdFormaPagamento { get; set; }
    [JsonIgnore] public int? NroParcelas { get; set; }
    [JsonIgnore] public int? PrimeiraParcela { get; set; }
    [JsonIgnore] public int? DemaisParcelas { get; set; }
    [JsonIgnore] public int? Pagamento_carteira { get; set; }
    [JsonIgnore] public int? Pagamento_boleto { get; set; }
    [JsonIgnore] public int? Pagamento_chequeproprio { get; set; }
    [JsonIgnore] public int? Pagamento_chequesocio { get; set; }
    [JsonIgnore] public int? Pagamento_chequeterceiro { get; set; }
    [JsonIgnore] public int? ConsumidorFinal { get; set; }
    [JsonIgnore] public int? Inativo { get; set; }
    [JsonIgnore] public int? AtualizacaoCadastral { get; set; }
    [JsonIgnore] public int? IdFinalidadeCompra { get; set; }
    [JsonIgnore] public int? Suframa { get; set; }
    [JsonIgnore] public int? IsencaoIPI { get; set; }
    [JsonIgnore] public int? IsencaoICMS { get; set; }
    [JsonIgnore] public int? IsencaoCOFINS { get; set; }
    [JsonIgnore] public int? IsencaoPIS { get; set; }
    [JsonIgnore] public int? IsencaoST { get; set; }
    [JsonIgnore] public string? ObservacoesNotaFiscal { get; set; }
    [JsonIgnore] public int? IdPais { get; set; }
    [JsonIgnore] public int? Transp_idTransp { get; set; }
    [JsonIgnore] public int? Transp_pagamento { get; set; }
    [JsonIgnore] public decimal? Transp_valor { get; set; }
    [JsonIgnore] public string? Transp_placa { get; set; }
    [JsonIgnore] public string? Transp_uf { get; set; }
    [JsonIgnore] public string? Transp_rntc { get; set; }
    [JsonIgnore] public int? Transp_entregar { get; set; }
    [JsonIgnore] public string? PrazoPagamento { get; set; }
    [JsonIgnore] public int? DiaFechamento { get; set; }
    [JsonIgnore] public int? DiaPagamento { get; set; }
    [JsonIgnore] public string? Cnae { get; set; }
    [JsonIgnore] public decimal? DescontoLimite { get; set; }
    [JsonIgnore] public decimal? DescontoPadrao { get; set; }
    [JsonIgnore] public int? IdPai { get; set; }
    [JsonIgnore] public int? SolicitacaoAprovacaoTabela { get; set; }
    [JsonIgnore] public DateTime? DataSAprovacaoTabela { get; set; }
    [JsonIgnore] public string? MensagemSAprovacaoTabela { get; set; }
    [JsonIgnore] public int? IdUsuarioSAprovacaoTabela { get; set; }
    [JsonIgnore] public string? MensagemAprovacaoTabela { get; set; }
    [JsonIgnore] public DateTime? DataAprovacaoTabela { get; set; }
    [JsonIgnore] public int? IdUsuarioAprovacaoTabela { get; set; }
    [JsonIgnore] public string? IdPlanoContabil { get; set; }
    [JsonIgnore] public int? IdIndicacao { get; set; }
    [JsonIgnore] public int? MotDesICMS { get; set; }
    [JsonIgnore] public int? IndDeduzDeson { get; set; }
    [JsonIgnore] public bool? NaoCobrarEmbalagem { get; set; }
}
