namespace Projeto.WEB.Model;
public class ControleCaixaOutputDto
{
    public int Id { get; set; }
    public int NumeroAtual { get; set; }
    public int TipoArquivoId { get; set; }
    public TipoArquivoDto? TipoArquivo { get; set; }
}
