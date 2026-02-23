using System.ComponentModel.DataAnnotations;

namespace Taskli.Application.DTOs;

public class SelectClientField {
    public string Fantasia { get; set; } = string.Empty;
    public string RazaoSocial { get; set; } = string.Empty;
    public string TipoPessoa { get; set; } = string.Empty;
    public string Cnpj { get; set; } = string.Empty;
    public string Ie { get; set; } = string.Empty;
    public string End_nomerua { get; set; } = string.Empty;
    public string End_numero { get; set; } = string.Empty;
    public string End_cep { get; set; } = string.Empty;
    public string End_complemento { get; set; } = string.Empty;
    public string End_bairro { get; set; } = string.Empty;
    public string End_cidade { get; set; } = string.Empty;
    public string End_estado { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Site { get; set; } = string.Empty;
    public string Telefone { get; set; } = string.Empty;
    public string Fax { get; set; } = string.Empty;
    public string End_logradouro { get; set; } = string.Empty;
    public string Observacoes { get; set; } = string.Empty;
    public string ObservacoesPrivada { get; set; } = string.Empty;
    public int? IdVendedor { get; set; }
    public decimal? Comissao { get; set; }
    public int? IdTabela { get; set; }
    public int? IdClasse { get; set; }
    public string Ent_cnpj { get; set; } = string.Empty;
    public string Ent_nomeRua { get; set; } = string.Empty;
    public string Ent_numero { get; set; } = string.Empty;
    public string Ent_cep { get; set; } = string.Empty;
    public string Ent_complemento { get; set; } = string.Empty;
    public string Ent_bairro { get; set; } = string.Empty;
    public string Ent_cidade { get; set; } = string.Empty;
    public string Ent_estado { get; set; } = string.Empty;
    public string Ent_logradouro { get; set; } = string.Empty;
    public int? IdSetor { get; set; }
    public string Ent_email { get; set; } = string.Empty;
    public string Cob_logradouro { get; set; } = string.Empty;
    public string Cob_nomeRua { get; set; } = string.Empty;
    public string Cob_numero { get; set; } = string.Empty;
    public string Cob_cep { get; set; } = string.Empty;
    public string Cob_complemento { get; set; } = string.Empty;
    public string Cob_bairro { get; set; } = string.Empty;
    public string Cob_cidade { get; set; } = string.Empty;
    public string Cob_estado { get; set; } = string.Empty;
    public string Cob_alertaVendas { get; set; } = string.Empty;
    public string Cob_observacoes { get; set; } = string.Empty;
    public string Cob_email { get; set; } = string.Empty;
    public decimal? Limite { get; set; }
    public string Serasa { get; set; } = string.Empty;
    public DateTime? DataFundacao { get; set; }
    public DateTime? DataCadastro { get; set; }
    public DateTime? DataAtualizacao { get; set; }
    public DateTime? DataUltimaCompra { get; set; }
    public DateTime? DataUltimoOrcamento { get; set; }
    public DateTime? DataConsultaSerasa { get; set; }
    public string RE1Nome { get; set; } = string.Empty;
    public string RE1cpf { get; set; } = string.Empty;
    public string RE1rg { get; set; } = string.Empty;
    public DateTime? RE1Nascimento { get; set; }
    public decimal? RE1Quota { get; set; }
    public string RE2Nome { get; set; } = string.Empty;
    public string RE2cpf { get; set; } = string.Empty;
    public string RE2rg { get; set; } = string.Empty;
    public DateTime? RE2Nascimento { get; set; }
    public decimal? RE2Quota { get; set; }
    public string RE3Nome { get; set; } = string.Empty;
    public string RE3cpf { get; set; } = string.Empty;
    public string RE3rg { get; set; } = string.Empty;
    public DateTime? RE3Nascimento { get; set; }
    public decimal? RE3Quota { get; set; }
    public decimal? CapitalSocial { get; set; }
    public int? StatusAtivo { get; set; }
    public int? IdFormaPagamento { get; set; }
    public int? NroParcelas { get; set; }
    public int? PrimeiraParcela { get; set; }
    public int? DemaisParcelas { get; set; }
    public int? Pagamento_carteira { get; set; }
    public int? Pagamento_boleto { get; set; }
    public int? Pagamento_chequeproprio { get; set; }
    public int? Pagamento_chequesocio { get; set; }
    public int? Pagamento_chequeterceiro { get; set; }
    public int? ConsumidorFinal { get; set; }
    public int? Inativo { get; set; }
    public int? AtualizacaoCadastral { get; set; }
    public int? IdFinalidadeCompra { get; set; }
    public int Suframa { get; set; }
    public int IsencaoIPI { get; set; }
    public int IsencaoICMS { get; set; }
    public int IsencaoCOFINS { get; set; }
    public int IsencaoPIS { get; set; }
    public int IsencaoST { get; set; }
    public string ObservacoesNotaFiscal { get; set; } = string.Empty;
    public int Transp_idTransp { get; set; }
    public int Transp_pagamento { get; set; }
    public decimal Transp_valor { get; set; }
    public string Transp_placa { get; set; } = string.Empty;
    public string Transp_uf { get; set; } = string.Empty;
    public string Transp_rntc { get; set; } = string.Empty;
    public int Transp_entregar { get; set; }
    public string PrazoPagamento { get; set; } = string.Empty;
    public int DiaFechamento { get; set; }
    public int DiaPagamento { get; set; }
    public string Cnae { get; set; } = string.Empty;
    public decimal DescontoLimite { get; set; }
    public decimal DescontoPadrao { get; set; }
    public int IdPai { get; set; }
    public int SolicitacaoAprovacaoTabela { get; set; }
    public DateTime? DataSAprovacaoTabela { get; set; }
    public string MensagemSAprovacaoTabela { get; set; } = string.Empty;
    public int IdUsuarioSAprovacaoTabela { get; set; }
    public string MensagemAprovacaoTabela { get; set; } = string.Empty;
    public DateTime? DataAprovacaoTabela { get; set; }
    public int IdUsuarioAprovacaoTabela { get; set; }
    public string IdPlanoContabil { get; set; } = string.Empty;
    public int IdIndicacao { get; set; }
    public int MotDesICMS { get; set; }
    public int IndDeduzDeson { get; set; }
    public bool NaoCobrarEmbalagem { get; set; }
}
