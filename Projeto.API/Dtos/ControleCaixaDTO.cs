using Projeto.API.Models;

namespace Projeto.API.Dtos;

public class ControleCaixaDTO
{
    public int Id { get; set; }
    public int NumeroAtual { get; set; }
    public int TipoArquivoId { get; set; }
    public TipoArquivo TipoArquivo { get; set; } = new TipoArquivo();
}
