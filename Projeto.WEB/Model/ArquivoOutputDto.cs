namespace Projeto.WEB.Model;

public class ArquivoOutputDto
{
    public int Id { get; set; }
    public string? Descricao { get; set; }
    public DateTime Competencia { get; set; }
    public DateTime DataCadastro { get; set; }
    public DateTime DataVencimento { get; set; }
    public bool Ativo { get; set; } = true;
    public string? Arquitetura { get; set; }
    public string? Pratelheira { get; set; }
    public string? PratelheiraLinha { get; set; }
    public string? PratelheiraColuna { get; set; }
    public string? Armario { get; set; } 
    public string? Gaveta { get; set; } 
    public DateTime DataDescarte { get; set; }
    public int NumeroCaixa { get; set; }
    public DateTime DataUltimaAtualizacao { get; set; }
    public string? PrimeiroUsuarioCadastro { get; set; }
    public string? UltimoUsuarioAtualizar { get; set; }

    public int TipoArquivoId { get; set; }
    public TipoArquivoDto? TipoArquivo { get; set; }
    public int UsuarioId { get; set; }
    public UsuarioOutputDto? Usuario { get; set; }
}
