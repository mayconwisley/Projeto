namespace Projeto.WEB.Model;
public class UsuarioOutputView
{
    public int TotalDados { get; set; }
    public int Pagina { get; set; }
    public int TotalPagina { get; set; }
    public int Tamanho { get; set; }
    public IEnumerable<UsuarioOutputDto>? Dados { get; set; }
}