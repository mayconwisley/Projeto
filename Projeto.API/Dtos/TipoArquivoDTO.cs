using Projeto.API.Models.Enum;
using System.ComponentModel.DataAnnotations;

namespace Projeto.API.Dtos;

public class TipoArquivoDTO
{
    public int Id { get; set; }
    [Required, MaxLength(500)]
    public string Descricao { get; set; } = string.Empty;
    [Required]
    public int Guardar { get; set; } = 0;
    [Required]
    public TempoEnum Tempo { get; set; }
    [Required]
    public bool SuporteItem { get; set; }
    [Required]
    public bool SuporteControleCaixa { get; set; }
    [Required]
    public bool Ativo { get; set; } = true;
}
