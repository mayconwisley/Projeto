using System.ComponentModel.DataAnnotations;

namespace Projeto.WEB.Model;

public class ControleCaixaInputDto
{    
    [Required]
    public int NumeroAtual { get; set; }
    [Required]
    public int TipoArquivoId { get; set; }
}
