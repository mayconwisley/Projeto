namespace Projeto.API.Dtos;

public class ControleCaixaOutputDTO
{
    public int Id { get; set; }
    public int NumeroAtual { get; set; }
    public int TipoArquivoId { get; set; }
    public TipoArquivoDTO TipoArquivo { get; set; } = new TipoArquivoDTO();
}
