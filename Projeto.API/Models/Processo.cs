namespace Projeto.API.Models;

public class Processo
{
    public int Id { get; set; }
    public DateTime DataEnvio { get; set; }
    public string? ParaQuem { get; set; }
    public string? Descricao { get; set; }
    public string? Status { get; set; }
    public int ItemArquivoId { get; set; }
    public ItemArquivo? ItemArquivo { get; set; }
}
