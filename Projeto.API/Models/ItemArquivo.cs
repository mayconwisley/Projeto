namespace Projeto.API.Models;

public class ItemArquivo
{
    public int Id { get; set; }
    public string? CodigoItem { get; set; }
    public string? Descricao { get; set; }
    public bool NoArquivo { get; set; }
    public int ArquivoId { get; set; }
    public Arquivo? Arquivo { get; set; }
}
