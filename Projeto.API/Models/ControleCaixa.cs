namespace Projeto.API.Models;

public class ControleCaixa
{
    public int Id { get; set; }
    public int NumeroAtual { get; set; }
    public int TipoArquivoId { get; set; }
    public TipoArquivo? TipoArquivo { get; set; }
}
