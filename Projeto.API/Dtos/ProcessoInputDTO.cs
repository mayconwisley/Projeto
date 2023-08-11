using System.ComponentModel.DataAnnotations;

namespace Projeto.API.Dtos;

public class ProcessoInputDTO
{
    public int Id { get; set; }
    [Required]
    public DateTime DataEnvio { get; set; } = new DateTime();
    [Required, MaxLength(255)]
    public string ParaQuem { get; set; } = string.Empty;
    [Required, MaxLength(500)]
    public string Descricao { get; set; } = string.Empty;
    [Required, MaxLength(255)]
    public string Status { get; set; } = string.Empty;
    [Required]
    public int ItemArquivoId { get; set; }
}
