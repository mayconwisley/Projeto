using System.ComponentModel.DataAnnotations;

namespace Projeto.API.Dtos;

public class ControleCaixaInputDTO
{
    public int Id { get; set; }
    [Required]
    public int NumeroAtual { get; set; }
    [Required]
    public int TipoArquivoId { get; set; }

}
