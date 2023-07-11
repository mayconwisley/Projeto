namespace Projeto.API.Models;

public class Processo
{
    public int Id { get; set; }
    public DateTime DataEnvio { get; set; } = new DateTime();
    public string ParaQuem { get; set; } = string.Empty;
    public string Descricao { get; set; } = string.Empty;
    public string Status { get; set; } = string.Empty;
    public int ItemArquivoId { get; set; }
    public ItemArquivo? ItemArquivo { get; set; }
}
