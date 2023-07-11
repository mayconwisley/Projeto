using Projeto.API.Models.Enum;
using System.ComponentModel.DataAnnotations;

namespace Projeto.API.Dtos;

public class ArquivoInputDTO
{
    public int Id { get; set; }
    [Required, MaxLength(500)]
    public string Descricao { get; set; } = string.Empty;
    [Required]
    public DateTime Competencia { get; set; }
    [Required]
    public DateTime DataCadastro { get; set; }
    public DateTime DataVencimento { get; set; }
    public bool Ativo { get; set; } = true;
    [Required]
    public ArquiteturaEnum Arquitetura { get; set; }
    [MaxLength(10)]
    public string Pratelheira { get; set; } = string.Empty;
    [MaxLength(10)]
    public string PratelheiraLinha { get; set; } = string.Empty;
    [MaxLength(10)]
    public string PratelheiraColuna { get; set; } = string.Empty;
    [MaxLength(10)]
    public string Armario { get; set; } = string.Empty;
    [MaxLength(10)]
    public string Gaveta { get; set; } = string.Empty;
    public DateTime DataDescarte { get; set; }
    public int NumeroCaixa { get; set; }
    [Required]
    public DateTime DataUltimaAtualizacao { get; set; }
    [Required]
    public string PrimeiroUsuarioCadastro { get; set; } = string.Empty;
    [Required]
    public string UltimoUsuarioAtualizar { get; set; } = string.Empty;
    [Required]
    public int TipoArquivoId { get; set; }
    [Required]
    public int UsuarioId { get; set; }

}
