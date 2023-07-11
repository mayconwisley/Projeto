namespace Projeto.API.Models;

public class ItemArquivo
{
    public int Id { get; set; }
    public string CodigoItem { get; set; } = string.Empty;
    public string Descricao { get; set; } = string.Empty;
    public bool NoArquivo { get; set; }
    public int ArquivoId { get; set; }
    public Arquivo? Arquivo { get; set; }
}
